// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the MIT License.
using Microsoft.CST.LogicalAnalyzer;
using Microsoft.CST.LogicalAnalyzer.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.CST.LogicalAnalyzer.Tests
{
    [TestClass]
    public class OperationsTests
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext _)
        {
            Strings.Setup();
        }

        [TestMethod]
        public void VerifyContainsAnyOperator()
        {
            var trueStringObject = new TestObject()
            {
                StringField = "ThisStringContainsMagic"
            };

            var falseStringObject = new TestObject()
            {
                StringField = "ThisStringDoesNot"
            };

            var stringContains = new Rule("String Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringField", OPERATION.CONTAINS_ANY)
                    {
                        Data = new List<string>()
                        {
                            "Magic",
                        }
                    }
                }
            };

            var stringAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { stringContains }; ;

            Assert.IsTrue(stringAnalyzer.Analyze(ruleList, trueStringObject).Any());
            Assert.IsFalse(stringAnalyzer.Analyze(ruleList, falseStringObject).Any());

            var trueListObject = new TestObject()
            {
                StringListField = new List<string>()
                {
                    "One",
                    "Magic",
                    "Three"
                }
            };

            var falseListObject = new TestObject()
            {
                StringListField = new List<string>()
                {
                    "One",
                    "Two",
                    "Three"
                }
            };

            var listContains = new Rule("List Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringListField", OPERATION.CONTAINS_ANY)
                    {
                        Data = new List<string>()
                        {
                            "Magic",
                            "Abra Kadabra"
                        }
                    }
                }
            };

            var listAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { listContains }; ;

            Assert.IsTrue(listAnalyzer.Analyze(ruleList, trueListObject).Any());
            Assert.IsFalse(listAnalyzer.Analyze(ruleList, falseListObject).Any());

            var trueStringDictObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>()
                {
                    { "One", "Hocus Pocus" },
                    { "Two", "Abra Kadabra" },
                    { "Magic Word", "Please" }
                }
            };

            var falseStringDictObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>()
                {
                    { "One", "Magic" },
                    { "Two", "Show" },
                    { "Three", "Please" }
                }
            };

            var stringDictContains = new Rule("String Dict Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringDictField", OPERATION.CONTAINS_ANY)
                    {
                        DictData = new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("Magic Word","Please")
                        }
                    }
                }
            };

            var stringDictAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { stringDictContains }; ;

            Assert.IsTrue(stringDictAnalyzer.Analyze(ruleList, trueStringDictObject).Any());
            Assert.IsFalse(stringDictAnalyzer.Analyze(ruleList, falseStringDictObject).Any());

            var trueListDictObject = new TestObject()
            {
                StringListDictField = new Dictionary<string, List<string>>()
                {
                    {
                        "Magic Words", new List<string>()
                        {
                            "Please",
                            "Thank You"
                        }
                    }
                }
            };

            var falseListDictObject = new TestObject()
            {
                StringListDictField = new Dictionary<string, List<string>>()
                {
                    {
                        "Magic Words", new List<string>()
                        {
                            "Scallywag",
                            "Magic"
                        }
                    }
                }
            };

            var listDictContains = new Rule("List Dict Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringListDictField", OPERATION.CONTAINS_ANY)
                    {
                        DictData = new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("Magic Words","Please"),
                            new KeyValuePair<string, string>("Magic Words","Thank You"),
                        }
                    }
                }
            };

            var listDictAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { listDictContains }; ;

            Assert.IsTrue(listDictAnalyzer.Analyze(ruleList, trueListDictObject).Any());
            Assert.IsFalse(listDictAnalyzer.Analyze(ruleList, falseListDictObject).Any());
        }

        [TestMethod]
        public void VerifyContainsOperator()
        {
            var trueStringObject = new TestObject()
            {
                StringField = "ThisStringContainsMagic"
            };

            var falseStringObject = new TestObject()
            {
                StringField = "ThisStringDoesNot"
            };

            var stringContains = new Rule("String Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringField", OPERATION.CONTAINS)
                    {
                        Data = new List<string>()
                        {
                            "Magic",
                            "String"
                        }
                    }
                }
            };

            var stringAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { stringContains }; ;

            Assert.IsTrue(stringAnalyzer.Analyze(ruleList, trueStringObject).Any());
            Assert.IsFalse(stringAnalyzer.Analyze(ruleList, falseStringObject).Any());

            var trueListObject = new TestObject()
            {
                StringListField = new List<string>()
                {
                    "One",
                    "Magic",
                    "Abra Kadabra"
                }
            };

            var falseListObject = new TestObject()
            {
                StringListField = new List<string>()
                {
                    "One",
                    "Two",
                    "Three"
                }
            };

            var listContains = new Rule("List Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringListField", OPERATION.CONTAINS)
                    {
                        Data = new List<string>()
                        {
                            "Magic",
                            "Abra Kadabra"
                        }
                    }
                }
            };

            var listAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { listContains }; ;

            Assert.IsTrue(listAnalyzer.Analyze(ruleList, trueListObject).Any());
            Assert.IsFalse(listAnalyzer.Analyze(ruleList, falseListObject).Any());

            var trueStringDictObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>()
                {
                    { "One", "Money" },
                    { "Two", "Show" },
                    { "Magic Word", "Please" }
                }
            };

            var falseStringDictObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>()
                {
                    { "One", "Magic" },
                    { "Two", "Show" },
                    { "Three", "Please" }
                }
            };

            var stringDictContains = new Rule("String Dict Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringDictField", OPERATION.CONTAINS)
                    {
                        DictData = new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("Magic Word","Please"),
                            new KeyValuePair<string, string>("Two","Show"),
                            new KeyValuePair<string, string>("One","Money")
                        }
                    }
                }
            };

            var stringDictAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { stringDictContains }; ;

            Assert.IsTrue(stringDictAnalyzer.Analyze(ruleList, trueStringDictObject).Any());
            Assert.IsFalse(stringDictAnalyzer.Analyze(ruleList, falseStringDictObject).Any());

            var trueListDictObject = new TestObject()
            {
                StringListDictField = new Dictionary<string, List<string>>()
                {
                    {
                        "Magic Words", new List<string>()
                        {
                            "Please",
                            "Thank You"
                        }
                    }
                }
            };

            var falseListDictObject = new TestObject()
            {
                StringListDictField = new Dictionary<string, List<string>>()
                {
                    {
                        "Magic Words", new List<string>()
                        {
                            "Scallywag",
                            "Magic"
                        }
                    }
                }
            };

            var listDictContains = new Rule("List Dict Contains Any Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringListDictField", OPERATION.CONTAINS)
                    {
                        DictData = new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("Magic Words","Please"),
                            new KeyValuePair<string, string>("Magic Words","Thank You"),
                        }
                    }
                }
            };

            var listDictAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { listDictContains }; ;

            Assert.IsTrue(listDictAnalyzer.Analyze(ruleList, trueListDictObject).Any());
            Assert.IsFalse(listDictAnalyzer.Analyze(ruleList, falseListDictObject).Any());
        }

        [TestMethod]
        public void VerifyContainsKeyOperator()
        {
            var trueAlgDict = new TestObject()
            {
                StringDictField = new Dictionary<string,string>()
                {
                    { "Magic", "Anything" }
                }
            };

            var falseAlgDict = new TestObject()
            {
                StringDictField = new Dictionary<string, string>()
                {
                    { "No Magic", "Anything" }
                }
            };

            var algDictContains = new Rule("Alg Dict Changed PCR 1")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringDictField", OPERATION.CONTAINS_KEY)
                    {
                        Data = new List<string>()
                        {
                            "Magic"
                        }
                    }
                }
            };

            var algDictAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { algDictContains }; ;

            Assert.IsTrue(algDictAnalyzer.Analyze(ruleList, trueAlgDict).Any());
            Assert.IsFalse(algDictAnalyzer.Analyze(ruleList, falseAlgDict).Any());
        }

        [TestMethod]
        public void VerifyEndsWithOperator()
        {
            var trueEndsWithObject = "ThisStringEndsWithMagic";
            var falseEndsWithObject = "ThisStringHasMagicButDoesn't";

            var endsWithRule = new Rule("Ends With Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.ENDS_WITH)
                    {
                        Data = new List<string>()
                        {
                            "Magic"
                        }
                    }
                }
            };

            var endsWithAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { endsWithRule }; ;

            Assert.IsTrue(endsWithAnalyzer.Analyze(ruleList, trueEndsWithObject).Any());
            Assert.IsFalse(endsWithAnalyzer.Analyze(ruleList, falseEndsWithObject).Any());
        }

        [TestMethod]
        public void VerifyStartsWithOperator()
        {
            var trueEndsWithObject = "MagicStartsThisStringOff";
            var falseEndsWithObject = "ThisStringHasMagicButLater";

            var startsWithRule = new Rule("Starts With Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.STARTS_WITH)
                    {
                        Data = new List<string>()
                        {
                            "Magic"
                        }
                    }
                }
            };

            var analyzer = new Analyzer();
            var ruleList = new List<Rule>() { startsWithRule }; ;

            Assert.IsTrue(analyzer.Analyze(ruleList, trueEndsWithObject).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, falseEndsWithObject).Any());
        }

        [TestMethod]
        public void VerifyEqOperator()
        {
            var assertTrueObject = new TestObject()
            {
                StringField = "Magic",
                BoolField = true,
                IntField = 700
            }; 
            
            var assertFalseObject = new TestObject()
            {
                StringField = "NotMagic",
                BoolField = false,
                IntField = 701
            };

            var stringEquals = new Rule("String Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringField", OPERATION.EQ)
                    {
                        Data = new List<string>()
                        {
                            "Magic"
                        }
                    }
                }
            };

            var boolEquals = new Rule("Bool Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("BoolField", OPERATION.EQ)
                    {
                        Data = new List<string>()
                        {
                            "True"
                        }
                    }
                }
            };

            var intEquals = new Rule("Int Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.EQ)
                    {
                        Data = new List<string>()
                        {
                            "700"
                        }
                    }
                }
            };

            var analyzer = new Analyzer();
            var ruleList = new List<Rule>() { boolEquals, intEquals, stringEquals };

            var trueObjectResults = analyzer.Analyze(ruleList, assertTrueObject);
            var falseObjectResults = analyzer.Analyze(ruleList, assertFalseObject);

            Assert.IsTrue(trueObjectResults.Any(x => x.Name == "Bool Equals Rule"));
            Assert.IsTrue(trueObjectResults.Any(x => x.Name == "Int Equals Rule"));
            Assert.IsTrue(trueObjectResults.Any(x => x.Name == "String Equals Rule"));

            Assert.IsFalse(falseObjectResults.Any(x => x.Name == "Bool Equals Rule"));
            Assert.IsFalse(falseObjectResults.Any(x => x.Name == "Int Equals Rule"));
            Assert.IsFalse(falseObjectResults.Any(x => x.Name == "String Equals Rule"));
        }

        [TestMethod]
        public void VerifyNeqOperator()
        {
            var assertFalseObject = new TestObject()
            {
                StringField = "Magic",
                BoolField = true,
                IntField = 700
            };

            var assertTrueObject = new TestObject()
            {
                StringField = "NotMagic",
                BoolField = false,
                IntField = 701
            };

            var stringNotEquals = new Rule("String Not Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("StringField", OPERATION.NEQ)
                    {
                        Data = new List<string>()
                        {
                            "Magic"
                        }
                    }
                }
            };

            var boolNotEquals = new Rule("Bool Not Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("BoolField", OPERATION.NEQ)
                    {
                        Data = new List<string>()
                        {
                            "True"
                        }
                    }
                }
            };

            var intNotEquals = new Rule("Int Not Equals Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.NEQ)
                    {
                        Data = new List<string>()
                        {
                            "700"
                        }
                    }
                }
            };

            var analyzer = new Analyzer();
            var ruleList = new List<Rule>() { boolNotEquals, intNotEquals, stringNotEquals };

            var trueObjectResults = analyzer.Analyze(ruleList, assertTrueObject);
            var falseObjectResults = analyzer.Analyze(ruleList, assertFalseObject);

            Assert.IsTrue(trueObjectResults.Any(x => x == boolNotEquals));
            Assert.IsTrue(trueObjectResults.Any(x => x == stringNotEquals));
            Assert.IsTrue(trueObjectResults.Any(x => x == intNotEquals));

            Assert.IsFalse(falseObjectResults.Any(x => x == boolNotEquals));
            Assert.IsFalse(falseObjectResults.Any(x => x == stringNotEquals));
            Assert.IsFalse(falseObjectResults.Any(x => x == intNotEquals));
        }

        [TestMethod]
        public void VerifyGtOperator()
        {
            var trueGtObject = new TestObject()
            {
                IntField = 9001
            };
            var falseGtObject = new TestObject()
            {
                IntField = 9000
            };

            var gtRule = new Rule("Gt Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.GT)
                    {
                        Data = new List<string>()
                        {
                            "9000"
                        }
                    }
                }
            };

            var badGtRule = new Rule("Bad Gt Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.GT)
                    {
                        Data = new List<string>()
                        {
                            "CONTOSO"
                        }
                    }
                }
            };

            var gtAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { gtRule }; ;

            Assert.IsTrue(gtAnalyzer.Analyze(ruleList, trueGtObject).Any());
            Assert.IsFalse(gtAnalyzer.Analyze(ruleList, falseGtObject).Any());

            var badGtAnalyzer = new Analyzer();
            ruleList = new List<Rule>() { badGtRule }; ;

            Assert.IsFalse(badGtAnalyzer.Analyze(ruleList, trueGtObject).Any());
            Assert.IsFalse(badGtAnalyzer.Analyze(ruleList, falseGtObject).Any());
        }

        [TestMethod]
        public void VerifyLtOperator()
        {
            var trueGtObject = new TestObject()
            {
                IntField = 8999
            };
            var falseGtObject = new TestObject()
            {
                IntField = 9000
            };

            var gtRule = new Rule("Lt Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.LT)
                    {
                        Data = new List<string>()
                        {
                            "9000"
                        }
                    }
                }
            };

            var badGtRule = new Rule("Bad Lt Rule")
            {
                Target = "TestObject",
                Clauses = new List<Clause>()
                {
                    new Clause("IntField", OPERATION.LT)
                    {
                        Data = new List<string>()
                        {
                            "CONTOSO"
                        }
                    }
                }
            };

            var ltAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { gtRule }; ;

            Assert.IsTrue(ltAnalyzer.Analyze(ruleList, trueGtObject).Any());
            Assert.IsFalse(ltAnalyzer.Analyze(ruleList, falseGtObject).Any());

            ruleList = new List<Rule>() { badGtRule }; ;

            Assert.IsFalse(ltAnalyzer.Analyze(ruleList, trueGtObject).Any());
            Assert.IsFalse(ltAnalyzer.Analyze(ruleList, falseGtObject).Any());
        }

        [TestMethod]
        public void VerifyIsAfterOperator()
        {
            var falseIsAfterObject = DateTime.MinValue;

            var trueIsAfterObject = DateTime.MaxValue;

            var isAfterRule = new Rule("Is After Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_AFTER)
                    {
                        Data = new List<string>()
                        {
                            DateTime.Now.ToString()
                        }
                    }
                }
            };

            var isAfterAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { isAfterRule }; ;

            Assert.IsTrue(isAfterAnalyzer.Analyze(ruleList, trueIsAfterObject).Any());
            Assert.IsFalse(isAfterAnalyzer.Analyze(ruleList, falseIsAfterObject).Any());

            var isAfterRuleShortDate = new Rule("Is After Short Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_AFTER)
                    {
                        Data = new List<string>()
                        {
                            DateTime.Now.ToShortDateString()
                        }
                    }
                }
            };

            ruleList = new List<Rule>() { isAfterRuleShortDate }; ;

            Assert.IsTrue(isAfterAnalyzer.Analyze(ruleList, trueIsAfterObject).Any());
            Assert.IsFalse(isAfterAnalyzer.Analyze(ruleList, falseIsAfterObject).Any());
        }

        [TestMethod]
        public void VerifyIsBeforeOperator()
        {
            var falseIsBeforeObject = DateTime.MaxValue;

            var falseIsAfterObject = DateTime.MinValue;

            var isBeforeRule = new Rule("Is Before Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_BEFORE)
                    {
                        Data = new List<string>()
                        {
                            DateTime.Now.ToString()
                        }
                    }
                }
            };

            var analyzer = new Analyzer();
            var ruleList = new List<Rule>() { isBeforeRule }; ;

            Assert.IsTrue(analyzer.Analyze(ruleList, falseIsAfterObject).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, falseIsBeforeObject).Any());

            var isBeforeShortRule = new Rule("Is Before Short Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_BEFORE)
                    {
                        Data = new List<string>()
                        {
                            DateTime.Now.ToShortDateString()
                        }
                    }
                }
            };

            ruleList = new List<Rule>() { isBeforeShortRule }; ;

            Assert.IsTrue(analyzer.Analyze(ruleList, falseIsAfterObject).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, falseIsBeforeObject).Any());
        }

        [TestMethod]
        public void VerifyIsExpiredOperation()
        {
            var falseIsExpiredObject = DateTime.MaxValue;

            var trueIsExpiredObject = DateTime.MinValue;

            var isExpiredRule = new Rule("Is Expired Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_EXPIRED)
                }
            };

            var isAfterAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { isExpiredRule }; ;

            Assert.IsTrue(isAfterAnalyzer.Analyze(ruleList, trueIsExpiredObject).Any());
            Assert.IsFalse(isAfterAnalyzer.Analyze(ruleList, falseIsExpiredObject).Any());
        }

        [TestMethod]
        public void VerifyIsNullOperator()
        {

            var isNullRule = new Rule("Is Null Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_NULL)
                }
            };

            var isNullAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { isNullRule }; ;

            Assert.IsTrue(isNullAnalyzer.Analyze(ruleList, null).Any());
            Assert.IsFalse(isNullAnalyzer.Analyze(ruleList, "Not Null").Any());
        }

        [TestMethod]
        public void VerifyIsTrueOperator()
        {
            var isTrueRule = new Rule("Is True Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.IS_TRUE)
                }
            };

            var isTrueAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { isTrueRule }; ;

            Assert.IsTrue(isTrueAnalyzer.Analyze(ruleList, true).Any());
            Assert.IsFalse(isTrueAnalyzer.Analyze(ruleList, false).Any());
        }

        [TestMethod]
        public void VerifyRegexOperator()
        {
            var falseRegexObject = "TestPathHere";
            var trueRegexObject = "Directory/File";

            var regexRule = new Rule("Regex Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.REGEX)
                    {
                        Data = new List<string>()
                        {
                            ".+\\/.+"
                        }
                    }
                }
            };

            var regexAnalyzer = new Analyzer();
            var ruleList = new List<Rule>() { regexRule }; ;

            Assert.IsTrue(regexAnalyzer.Analyze(ruleList, trueRegexObject).Any());
            Assert.IsFalse(regexAnalyzer.Analyze(ruleList, falseRegexObject).Any());
        }

        [TestMethod]
        public void VerifyWasModifiedOperator()
        {
            var firstObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>() { { "Magic Word", "Please" }, { "Another Key", "Another Value" } }
            };

            var secondObject = new TestObject()
            {
                StringDictField = new Dictionary<string, string>() { { "Magic Word", "Abra Kadabra" }, { "Another Key", "A Different Value" } }
            };

            var wasModifiedRule = new Rule("Was Modified Rule")
            {
                Clauses = new List<Clause>()
                {
                    new Clause(OPERATION.WAS_MODIFIED)
                }
            };

            var analyzer = new Analyzer();
            var ruleList = new List<Rule>() { wasModifiedRule }; ;

            Assert.IsTrue(analyzer.Analyze(ruleList, true, false).Any());
            Assert.IsTrue(analyzer.Analyze(ruleList, "A String", "Another string").Any());
            Assert.IsTrue(analyzer.Analyze(ruleList, 3, 4).Any());
            Assert.IsTrue(analyzer.Analyze(ruleList, new List<string>() { "One", "Two" }, new List<string>() { "Three", "Four" }).Any());
            Assert.IsTrue(analyzer.Analyze(ruleList, firstObject, secondObject).Any());


            Assert.IsFalse(analyzer.Analyze(ruleList, true, true).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, "A String", "A String").Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, 3, 3).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, new List<string>() { "One", "Two" }, new List<string>() { "One", "Two" }).Any());
            Assert.IsFalse(analyzer.Analyze(ruleList, firstObject, firstObject).Any());
        }
    }
}