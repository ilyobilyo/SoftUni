namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestConstructorAndCount")]
        public void Test_Constructor_And_Count_Propery(Person[] costructorParams, Person[] addParams, int expectedCount)
        {
            Database db = new Database(costructorParams);
            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.That(db.Count, Is.EqualTo(expectedCount));
        }

        public static IEnumerable<TestCaseData> TestConstructorAndCount()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                        new Person(3, "zxc"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),

                    },
                    new Person[]
                    {
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),

                    },
                    9),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),
                    },
                    3),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestAddRangeMethodThrowsExeption")]
        public void Test_AddRange_Method_Throws_An_Exeption(Person[] costructorParams, Person[] addParams)
        {
            Database db = new Database();

            Assert.Throws<ArgumentException>(() =>
            {
                db = new Database(costructorParams);
            });
        }

        public static IEnumerable<TestCaseData> TestAddRangeMethodThrowsExeption()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "pasdaot"),
                        new Person(8, "pdafopo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "qdsq"),
                        new Person(14, "pp"),
                        new Person(15, "[ds["),
                        new Person(16, "ppasdasdpp"),
                        new Person(17, "kjppkj"),
                    },
                    new Person[0]
                    ),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestAddMethodThrowsExeptionIfAddMoreThan16Persons")]
        public void Test_AddMethod_Throws_Exeption_If_Add_More_Than_16_Persons(Person[] costructorParams, Person[] addParams)
        {
            Database db = new Database(costructorParams);

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < addParams.Length; i++)
                {
                    db.Add(addParams[i]);
                }
            });


        }

        public static IEnumerable<TestCaseData> TestAddMethodThrowsExeptionIfAddMoreThan16Persons()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                        new Person(3, "zxc"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                    },
                    new Person[]
                    {
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "qq"),
                        new Person(14, "pp"),
                        new Person(15, "[["),
                        new Person(16, "pppp"),
                        new Person(17, "kjppkj"),

                    }
                    ),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "qq"),
                        new Person(14, "pp"),
                        new Person(15, "[["),
                        new Person(16, "pppp"),
                        new Person(17, "kjppkj"),
                    }
                    )
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestAddMethodThrowsExeptionIfThereAlreadyUsersWithThisUsername")]
        public void Test_AddMethod_Throws_Exeption_If_There_Already_Users_With_This_Username(Person[] costructorParams, Person[] addParams)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(costructorParams);
                for (int i = 0; i < addParams.Length; i++)
                {
                    db.Add(addParams[i]);
                }
            });
        }

        public static IEnumerable<TestCaseData> TestAddMethodThrowsExeptionIfThereAlreadyUsersWithThisUsername()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ils"),
                        new Person(2, "Ils"),
                        new Person(3, "zxc"),
                        new Person(4, "zxc"),
                        new Person(5, "jkuol"),
                        new Person(6, "jkuol"),
                    },
                    new Person[]
                    {
                        new Person(7, "Ils"),
                        new Person(8, "zxc"),
                        new Person(9, "jkuol"),
                        new Person(10, "zxc"),
                        new Person(11, "jkuol"),
                        new Person(12, "www"),
                        new Person(13, "www"),
                        new Person(14, "pp"),
                    }
                    ),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "pot"),
                        new Person(3, "Ils"),
                        new Person(4, "Ils"),
                        new Person(5, "www"),
                        new Person(6, "www"),
                        new Person(7, "Ils"),
                        new Person(8, "popo"),
                        new Person(9, "Ils"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "ttt"),
                        new Person(14, "pp"),
                        new Person(15, "pp"),
                    }
                    ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "Ils"),
                        new Person(6, "Ils"),
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "www"),
                    },
                    new Person[0]
                    ),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestAddMethodThrowsExeptionIfThereAlreadyUsersWithThisId")]
        public void Test_AddMethod_Throws_Exeption_If_There_Already_Users_With_This_Id(Person[] costructorParams, Person[] addParams)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(costructorParams);
                for (int i = 0; i < addParams.Length; i++)
                {
                    db.Add(addParams[i]);
                }
            });
        }

        public static IEnumerable<TestCaseData> TestAddMethodThrowsExeptionIfThereAlreadyUsersWithThisId()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Ils"),
                        new Person(1, "qe"),
                        new Person(3, "zxc"),
                        new Person(3, "rt"),
                        new Person(5, "jkuol"),
                        new Person(5, "trl"),
                    },
                    new Person[]
                    {
                        new Person(7, "john"),
                        new Person(7, "cena"),
                        new Person(9, "like"),
                        new Person(10, "mike"),
                        new Person(10, "fast"),
                        new Person(12, "and"),
                        new Person(12, "furious"),
                        new Person(9, "pp"),
                    }
                    ),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(1, "top"),
                        new Person(3, "Ils"),
                        new Person(3, "siuwe"),
                        new Person(5, "www"),
                        new Person(5, "zxc"),
                        new Person(7, "vb"),
                        new Person(7, "popo"),
                        new Person(9, "hjh"),
                        new Person(10, "rrr"),
                        new Person(10, "ttt"),
                        new Person(12, "eerr"),
                        new Person(12, "eee"),
                        new Person(15, "wwwqq"),
                        new Person(15, "uiop"),
                    }
                    ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(1, "fpo"),
                        new Person(3, "siiiit"),
                        new Person(3, "kane"),
                        new Person(5, "undertaker"),
                        new Person(5, "Ils"),
                        new Person(7, "top"),
                        new Person(7, "popo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(10, "ttt"),
                        new Person(12, "asdq"),
                        new Person(12, "www"),
                    },
                    new Person[0]
                    ),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }


        [TestCaseSource("TestAddMethodAddingValidPersons")]
        public void Test_AddMethod_Adding_Valid_Persons(Person[] costructorParams, Person[] addParams, int expectedCount)
        {
            Database db = new Database(costructorParams);
            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.That(expectedCount, Is.EqualTo(db.Count));
        }

        public static IEnumerable<TestCaseData> TestAddMethodAddingValidPersons()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                        new Person(3, "zxc"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                    },
                    new Person[]
                    {
                        new Person(7, "pot"),
                        new Person(8, "popo"),
                        new Person(9, "kjkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "qq"),
                        new Person(14, "pp")

                    },
                    14),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "top"),
                        new Person(8, "klopl"),
                        new Person(9, "kjdfskj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                        new Person(13, "qq"),
                    },
                    13),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "pt"),
                        new Person(8, "ppo"),
                        new Person(9, "kjkjhkj"),
                        new Person(10, "rrr"),
                        new Person(11, "ttt"),
                        new Person(12, "www"),
                    },
                    new Person[0],
                    12),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestRemovePersonsFromDatabse")]
        public void Test_Remove_Persons_From_Database(Person[] costructorParams, Person[] addParams, int removeCount, int expectedCount)
        {
            Database db = new Database(costructorParams);
            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            for (int i = 0; i < removeCount; i++)
            {
                db.Remove();
            }

            Assert.That(expectedCount, Is.EqualTo(db.Count));
        }

        public static IEnumerable<TestCaseData> TestRemovePersonsFromDatabse()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    3,
                    3),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    8,
                    0),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "poqwepo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                    },
                    new Person[0],
                    4,
                    1),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestRemoveMethodThrowsExeptionWhenDatabaseIsEmpty")]
        public void Test_Remove_Method_Throws_Exeption_When_Database_Is_Empty(Person[] costructorParams, Person[] addParams, int removeCount)
        {
            Database database = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                database.Add(addParams[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < removeCount; i++)
                {
                    database.Remove();
                }

            });
        }

        public static IEnumerable<TestCaseData> TestRemoveMethodThrowsExeptionWhenDatabaseIsEmpty()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    7),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    9),
                new TestCaseData(
                    new Person[0],
                    new Person[0],
                    4),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestFindByUsernameThrowsExeptionWhenNoUserIsPresentByThisUsername")]
        public void Test_FindByUsername_Throws_Exeption_When_No_User_Is_Present_By_This_Username(Person[] costructorParams, Person[] addParams, string username)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(username);
            });
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameThrowsExeptionWhenNoUserIsPresentByThisUsername()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    "ils"),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    "ils"),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(2, "dsa"),
                        new Person(3, "cvx"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    "isl"),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestFindByUsernameThrowsExeptionWhenUsernameParameterIsEmptyString")]
        public void Test_FindByUsername_Throws_Exeption_When_Username_Parameter_Is_Empty_String(Person[] costructorParams, Person[] addParams, string username)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(username);
            });
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameThrowsExeptionWhenUsernameParameterIsEmptyString()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    ""),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    ""),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(2, "dsa"),
                        new Person(3, "cvx"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    ""),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestFindByUsernameGetPersonByUsername")]
        public void Test_FindByUsername_Get_Person_By_Username(Person[] costructorParams, Person[] addParams, string username)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Person searchedPerson = db.FindByUsername(username);

            Assert.That(username, Is.EqualTo(searchedPerson.UserName));
        }

        public static IEnumerable<TestCaseData> TestFindByUsernameGetPersonByUsername()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "Luke"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    "Luke"),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "GachoEmpepe"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    "GachoEmpepe"
                    ),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(2, "dsa"),
                        new Person(3, "Iliev"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    "Iliev")
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }


        [TestCaseSource("TestFindByIdThrowsExeptionIfNoUserIsPresentByThisId")]
        public void Test_FindById_Throws_Exeption_If_No_User_Is_Present_By_This_Id(Person[] costructorParams, Person[] addParams, long id)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(id);
            });
        }

        public static IEnumerable<TestCaseData> TestFindByIdThrowsExeptionIfNoUserIsPresentByThisId()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    1111111111111111),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    23232323),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(2, "dsa"),
                        new Person(3, "cvx"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    45),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestFindByIdThrowsExeptionIfNegativeIdAreFound")]
        public void Test_FindById_Throws_Exeption_If_Negative_Id_Are_Found(Person[] costructorParams, Person[] addParams, long id)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(id);
            });
        }

        public static IEnumerable<TestCaseData> TestFindByIdThrowsExeptionIfNegativeIdAreFound()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    -1111111111111111),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(4, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    -23232323),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(2, "dsa"),
                        new Person(3, "cvx"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    -45),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestFindByIdReturnPersonWithThisId")]
        public void Test_FindById_Return_Person_With_This_Id(Person[] costructorParams, Person[] addParams, long id)
        {
            Database db = new Database(costructorParams);

            for (int i = 0; i < addParams.Length; i++)
            {
                db.Add(addParams[i]);
            }

            Person searchedPerson = db.FindById(id);

            Assert.That(searchedPerson.Id , Is.EqualTo(id));
        }

        public static IEnumerable<TestCaseData> TestFindByIdReturnPersonWithThisId()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "qweq"),
                        new Person(2, "asd"),
                    },
                    new Person[]
                    {
                        new Person(3, "pot"),
                        new Person(4, "popo"),
                        new Person(5, "kjkj"),
                        new Person(6, "rrr"),
                    },
                    3),
                new TestCaseData(
                    new Person[0],
                    new Person[]
                    {
                        new Person(1, "pot"),
                        new Person(2, "popo"),
                        new Person(3, "kjkj"),
                        new Person(44434532234234, "vbc"),
                        new Person(5, "jkuol"),
                        new Person(6, "yrtuy"),
                        new Person(7, "potqwe"),
                        new Person(8, "popqweo"),
                    },
                    44434532234234),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "asda"),
                        new Person(0, "dsa"),
                        new Person(3, "cvx"),
                        new Person(4, "erw"),
                        new Person(5, "htrh"),

                    },
                    new Person[0],
                    0),
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

    }
}
