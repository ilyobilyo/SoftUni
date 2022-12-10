using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            var id = booths.Models.Count + 1;

            IBooth booth = new Booth(id, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(x => x.Name == cocktailName)
                && booth.CocktailMenu.Models.Any(x => x.Size == size))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (size == "Small" || size == "Middle" || size == "Large")
            {
                ICocktail cocktail = null;

                switch (cocktailTypeName)
                {
                    case "Hibernation":
                        {
                            cocktail = new Hibernation(cocktailName, size);
                            break;
                        }
                    case "MulledWine":
                        {
                            cocktail = new MulledWine(cocktailName, size);
                            break;
                        }
                    default:
                        {
                            return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
                        }
                }

                booth.CocktailMenu.AddModel(cocktail);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(x => x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    {
                        delicacy = new Gingerbread(delicacyName);
                        break;
                    }
                case "Stolen":
                    {
                        delicacy = new Stolen(delicacyName);
                        break;
                    }
                default:
                    {
                        return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
                    }
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            booth.Charge();

            if (booth.IsReserved)
            {
                booth.ChangeStatus();
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths
                .Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            var orderSplit = order.Split("/");

            var itemTypeName = orderSplit[0];
            var itemName = orderSplit[1];
            var countOfOrderedPieces = double.Parse(orderSplit[2]);

            var booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            if (itemTypeName != "Hibernation"
                && itemTypeName != "MulledWine"
                && itemTypeName != "Gingerbread"
                && itemTypeName != "Stolen")
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if ((!booth.CocktailMenu.Models.Any(x => x.Name == itemName))
                && (!booth.DelicacyMenu.Models.Any(x => x.Name == itemName)))
            {
                return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                var sizeCocktail = orderSplit[3];

                var item = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == sizeCocktail);

                if (item == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, sizeCocktail, itemName);
                }

                booth.UpdateCurrentBill(item.Price * countOfOrderedPieces);
            }
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                var item = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName);

                if (item == null)
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(item.Price * countOfOrderedPieces);
            }

            return String.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
        }
    }
}
