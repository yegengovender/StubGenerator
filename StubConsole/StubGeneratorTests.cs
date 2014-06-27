using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StubConsole
{
    [TestClass]
    public class StubGeneratorTests
    {
        private StubGenerator _stubGenerator;
        [TestInitialize]
        public void Setup()
        {
            _stubGenerator = new StubGenerator(typeof(ITargetObject));
        }

        [TestMethod]
        public void ClassDeclaration()
        {
            var declaration = _stubGenerator.Declaration;
            Assert.AreEqual("public ITargetObject TargetObjectFake", declaration);
        }

        [TestMethod]
        public void CreatesMethods()
        {
            var methods = _stubGenerator.Methods;
            Assert.AreEqual(3, methods.Count);
        }

        [TestMethod]
        public void CreatesMethodSignatures()
        {
            var methods = _stubGenerator.Methods;
            Assert.AreEqual("public String TheString", methods[0].Signature);
            Assert.AreEqual("public Int32 ANumber", methods[1].Signature);
            Assert.AreEqual("public TargetObj Obj", methods[2].Signature);
        }

        [TestMethod]
        public void ChecksIfReturnTypeIsBasic()
        {
            var methods = _stubGenerator.Methods;
            Assert.IsTrue(methods[0].IsBasic);
            Assert.IsTrue(methods[1].IsBasic);
            Assert.IsFalse(methods[2].IsBasic);
        }

        [TestMethod]
        public void CreatesMethodReturnValues()
        {
            var methods = _stubGenerator.Methods;
            Assert.AreEqual("\"TheString1\"", methods[0].ReturnValue);
            Assert.AreEqual("1", methods[1].ReturnValue);
            Assert.AreEqual("", methods[2].ReturnValue);
        }

        [TestMethod]
        public void CreatesFakeObjectReturnType()
        {
            var objectMethod = _stubGenerator.Methods[2];

            Assert.IsInstanceOfType(objectMethod.ReturnObject, typeof(FakeObject));

        }

        [TestMethod]
        public void FakeObjectDeclaration()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.AreEqual("new TargetObj", fakeObject.Declaration);
        }

        [TestMethod]
        public void CreatesFakeObjectProperties()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.AreEqual(3, fakeObject.Properties.Count);
        }

        [TestMethod]
        public void CreatesFakeObjectPropertieNames()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.AreEqual("TheString", fakeObject.Properties[0].Name);
            Assert.AreEqual("ANumber", fakeObject.Properties[1].Name);
            Assert.AreEqual("Obj", fakeObject.Properties[2].Name);
        }

        [TestMethod]
        public void ChecksWhichFakeObjectPropertiesIsBasic()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.IsTrue(fakeObject.Properties[0].IsBasic);
            Assert.IsTrue(fakeObject.Properties[1].IsBasic);
            Assert.IsFalse(fakeObject.Properties[2].IsBasic);
        }
        [TestMethod]
        public void CreatesFakeObjectPropertiesReturnValues()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.AreEqual("\"TheString1\"", fakeObject.Properties[0].ReturnValue);
            Assert.AreEqual("1", fakeObject.Properties[1].ReturnValue);
            Assert.AreEqual("", fakeObject.Properties[2].ReturnValue);
        }

        [TestMethod]
        public void CreatesRecursiveObjectProperty()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject;
            Assert.IsInstanceOfType(fakeObject.Properties[2].ReturnObject, typeof(FakeObject));           
        }

        [TestMethod]
        public void RecursiveObjectDeclaration()
        {
            var fakeObject = _stubGenerator.Methods[2].ReturnObject.Properties[2].ReturnObject;
            Assert.AreEqual("new SubObj", fakeObject.Declaration);
        }

    }
}