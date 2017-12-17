using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class PersonDbOperationTests
    {
        [Test]
        public void MyFirstTest()
        {
            var a = 1;
            var b = 2;
            var c = a + b;
            Assert.AreEqual(3, c);
        }
    }

    public class Job
    {
        public string Name { get; set; }

        public string Implementor { get; set; }
    }

    public class OneTimeJob
    {
        public List<Job> Jobs { get; set; }

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class Blahblah : Attribute
    {

    }


    public class OrderAttribute : Attribute
    {
        public int Order { get; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }

    public class OneTimeExecutionEngine
    {
        [Blahblah]
        public static void Start()
        {
            //var jsonFileText = File.ReadAllTExt("one-time-run.json");
            //var oneTimeJobs = Newtonsoft.Serializer.Deserialize<OneTimeJob>(jsonFileText);
            /*
             foreach(Var job in oneTimeJobs){
             Console.Log($"Excuting job : {job.Name}");
             var jobType=type.GetType(job.Implementor);
            var jobInstance = ACtivator.CreateInstance(jobType);
             jobInstance.Execute();
            }
             
             */
        }
    }

    [Order(1)]
    
    public class TestRun
    {
       
        public void Execute()
        {
            //Console.Log("TEst Run job has executed");
        }
    }
    [Order(10)]
    public class CleanDAtabase
    {
        public void Execute()
        {
            //Console.Log("TEst Run job has executed");
        }
    }
}
