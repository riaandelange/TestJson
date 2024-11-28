using System;

using delango.MySampleLibrary;

using Microsoft.Xrm.Sdk;

namespace TestJson
{
    public class HelloPerson : PluginBase
    {
        public HelloPerson(string unsecureConfiguration, string secureConfiguration) : base(typeof(HelloPerson))
        {
        }
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            var person = new Person("John Doe", 30);
            var greeting = person.SayHello();
            localPluginContext.Trace(greeting);
            throw new InvalidPluginExecutionException(greeting);
        }
    }
}
