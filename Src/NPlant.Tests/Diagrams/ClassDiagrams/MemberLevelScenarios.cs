using System.Collections.Generic;
using System.Linq;
using NPlant.Core;
using NPlant.MetaModel.ClassDiagraming;
using NUnit.Framework;

namespace NPlant.Tests.Diagrams.ClassDiagrams
{
    [TestFixture]
    public class MemberLevelScenarios
    {
        [Test]
        public void Test()
        {
            var simulation = new SimulatedClassDiagramGenerator(new Diagram());
            simulation.Generate();

            Assert.That(simulation.Classes[0].Name, Is.EqualTo("Foo"));
            Assert.That(simulation.Classes[1].Name, Is.EqualTo("Base"));

            AssertClassHasVisible(simulation.Classes[0], new []{"BaseProperty", "SomeProperty1", "SomeProperty3"});
        }

        private static void AssertClassHasVisible(RootClassDescriptor classs, params string[] expected)
        {
            if(expected == null)
                expected = new string[0];

            List<string> actual = new List<string>();

            classs.Members.ForEach(x =>
            {
                if (!x.IsHidden)
                    actual.Add(x.Name);
            });

            Assert.That(actual.Count, Is.EqualTo(expected.Length));

            foreach (var e in expected)
            {
                Assert.That(actual.Any(x => x == e), Is.True);
            }
        }

        public class Diagram : ClassDiagram
        {
            public Diagram()
            {
                Class<Foo>().ForMember(x => x.SomeProperty2).Hide();
            }
        }

        public class Base
        {
            public string BaseProperty { get; set; }
        }
        public class Foo : Base
        {
            public string SomeProperty1 { get; set; }
            public string SomeProperty2 { get; set; }
            public string SomeProperty3 { get; set; }
        }
    }
}