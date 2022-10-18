using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private readonly List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            renovators = new List<Renovator>();
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var renovatorToRemove = renovators.FirstOrDefault(x => x.Name == name);

            if (renovatorToRemove != null)
            {
                renovators.Remove(renovatorToRemove);

                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var removedRenovators = renovators.RemoveAll(x => x.Type == type);

            if (removedRenovators > 0)
            {
                return removedRenovators;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            var renovator = renovators.FirstOrDefault(x => x.Name == name);

            if (renovator == null)
            {
                return null;
            }

            renovator.Hired = true;

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var payedRenovators = renovators.Where(x => x.Days >= days).ToList();

            return payedRenovators;
        }

        public string Report()
        {
            var notHiredRenovators = renovators.Where(x => x.Hired == false).ToList();

            var sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in notHiredRenovators)
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
