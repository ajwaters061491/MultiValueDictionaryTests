using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiValueDictionary;
using System.Collections.Generic;

namespace MultiValueDictionaryTests
{
    [TestClass]
    public class CommandTests
    {
        #region Keys
        [TestMethod]
        public void Test_KeysPass()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar" });
            Commands cmd = new Commands();
            string expected = "1) foo\n";

            //Act
            string actual = cmd.keysCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_KeysPass failed.");
        }

        [TestMethod]
        public void Test_KeysError()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            Commands cmd = new Commands();
            string expected = "ERROR: No keys are available.\n";

            //Act
            string actual = cmd.keysCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_KeysError failed.");
        }
        #endregion

        #region Members
        [TestMethod]
        public void Test_membersCMDPass()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            string input = "members foo";
            Commands cmd = new Commands();
            string expected = "1) bar\n2) baz\n";

            //Act
            string actual = cmd.membersCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_membersCMDPass failed.");
        }

        [TestMethod]
        public void Test_membersCMDFail()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            string input = "members fun";
            Commands cmd = new Commands();
            string expected = "ERROR: key does not exist.\n";

            //Act
            string actual = cmd.membersCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_membersCMDFail failed.");
        }
        #endregion

        #region Allmembers
        [TestMethod]
        public void Test_allmembersCMDPass() //for copy paste purposes, delete when done
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            Commands cmd = new Commands();
            string expected = "1) bar\n2) baz\n";

            //Act
            string actual = cmd.allmembersCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_allmembersCMDPass failed.");
        }

        [TestMethod]
        public void Test_allmembersCMDNotPresent() //for copy paste purposes, delete when done
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            Commands cmd = new Commands();
            string expected = "";

            //Act
            string actual = cmd.allmembersCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_allmembersCMDNotPresent failed.");
        }
        #endregion

        #region Add
        [TestMethod]
        public void Test_addCMDPass() //for copy paste purposes, delete when done
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            string input = "add foo bar";
            Commands cmd = new Commands();
            bool expected = true;

            //Act
            cmd.addCMD(input, ref keyList);
            bool actual = keyList.ContainsKey("foo");


            //Assert
            Assert.AreEqual(expected, actual, "Test_addCMDPass failed.");
        }

        [TestMethod]
        public void Test_addCMDMemberPresent() //for copy paste purposes, delete when done
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            Commands cmd = new Commands();
            string input = "add foo bar";
            string expected = "ERROR: Entered member was found for that key.\n";

            //Act
            string actual = cmd.addCMD(input, ref keyList);


            //Assert
            Assert.AreEqual(expected, actual, "Test_addCMDMemberPresent failed.");
        }
        #endregion

        #region Remove

        [TestMethod]
        public void Test_removeCMDMemberPass() 
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            string input = "remove foo bar";
            Commands cmd = new Commands();
            int expected = 1;

            //Act
            cmd.addCMD(input, ref keyList);
            int actual = keyList.Values.Count;


            //Assert
            Assert.AreEqual(expected, actual, "Test_addCMDPass failed.");
        }

        [TestMethod]
        public void Test_removeCMDKeyPass() 
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar" });
            string input = "remove foo bar";
            Commands cmd = new Commands();
            int expected = 0;

            //Act
            cmd.removeCMD(input, ref keyList);
            int actual = keyList.Keys.Count;


            //Assert
            Assert.AreEqual(expected, actual, "Test_removeCMDKeyPass failed.");
        }

        [TestMethod]
        public void Test_removeCMDNoKeyPass() 
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fun", new List<string> { "bar" });
            string input = "remove foo bar";
            Commands cmd = new Commands();
            string expected = "ERROR: The key given does not exist.\n";

            //Act
            string actual = cmd.removeCMD(input, ref keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_removeCMDNoKeyPass failed.");
        }

        [TestMethod]
        public void Test_removeCMDNoMemberPass() 
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar" });
            string input = "remove foo baz";
            Commands cmd = new Commands();
            string expected = "ERROR: The member is not present for the given key.\n";

            //Act
            string actual = cmd.removeCMD(input, ref keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_removeCMDNoMemberPass failed.");
        }
        #endregion

        #region Removeall

        [TestMethod]
        public void Test_removeallPass() 
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            string input = "removeall foo";
            Commands cmd = new Commands();
            int expected = 0;

            //Act
            cmd.removeallCMD(input, ref keyList);
            int actual = keyList.Keys.Count;

            //Assert
            Assert.AreEqual(expected, actual, "Test_removeallPass failed.");
        }

        [TestMethod]
        public void Test_removeallNoKey()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            string input = "removeall foo";
            Commands cmd = new Commands();
            string expected = "ERROR: The key given does not exist.\n";

            //Act
            string actual = cmd.removeallCMD(input, ref keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_removeallNoKey failed.");
        }
        #endregion

        #region Clear
        [TestMethod]
        public void Test_clearPass()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("foo", new List<string> { "bar", "baz" });
            keyList.Add("fun", new List<string> { "bolt", "baz" });
            Commands cmd = new Commands();
            int expected = 0;

            //Act
            cmd.clearCMD(ref keyList);
            int actual = keyList.Keys.Count;

            //Assert
            Assert.AreEqual(expected, actual, "Test_clearPass failed."); 
        }
        #endregion

        #region Keyexists
        [TestMethod]
        public void Test_keyexistsExists()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fold", new List<string> { "bane", "baz" });
            string input = "keyexists fold";
            Commands cmd = new Commands();
            string expected = "True.\n";

            //Act
            string actual = cmd.keyexistsCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_keyexistsExists failed.");
        }

        [TestMethod]
        public void Test_keyexistsDoesNotExist()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fold", new List<string> { "bane", "baz" });
            string input = "keyexists foo";
            Commands cmd = new Commands();
            string expected = "False.\n";

            //Act
            string actual = cmd.keyexistsCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_keyexistsDoesNotExist failed.");
        }
        #endregion

        #region Memberexists
        [TestMethod]
        public void Test_memberexistsExists()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fold", new List<string> { "bane", "baz" });
            string input = "memberexists fold bane";
            Commands cmd = new Commands();
            string expected = "True.\n";

            //Act
            string actual = cmd.memberexistsCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_memberexistsExists failed.");
        }

        [TestMethod]
        public void Test_memberexistsCMDDoesNotExist()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fold", new List<string> { "bane", "baz" });
            string input = "memberexists fold boom";
            Commands cmd = new Commands();
            string expected = "False.\n";

            //Act
            string actual = cmd.memberexistsCMD(input, keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_memberexistsDoesNotExist failed.");
        }
        #endregion

        #region Items
        [TestMethod]
        public void Test_itemsPresent()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            keyList.Add("fold", new List<string> { "bane", "baz" });
            keyList.Add("foo", new List<string> { "bar", "bone", "bane", "baze" });
            keyList.Add("false", new List<string> { "barn" });
            Commands cmd = new Commands();
            string expected = "1) fold: bane\n2) fold: baz\n3) foo: bar\n4) foo: bone\n5) foo: bane\n6) foo: baze\n7) false: barn\n";

            //Act
            string actual = cmd.itemsCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_itemsPresent failed.");
        }

        [TestMethod]
        public void Test_itemsNotPresent()
        {
            //Arrange
            Dictionary<string, List<string>> keyList = new Dictionary<string, List<string>>();
            Commands cmd = new Commands();
            string expected = "";

            //Act
            string actual = cmd.itemsCMD(keyList);

            //Assert
            Assert.AreEqual(expected, actual, "Test_itemsNotPresent failed.");
        }
        #endregion


    }
}
