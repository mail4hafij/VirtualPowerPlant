using Emulator;
using Core.Business;
using Core.Business.Models;
using Core.Integration;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Core;
using Core.IoC;

// SOME BASIC SETUP START
// Adding appsettings.json to this project
var configuration = new ConfigurationBuilder().
                AddJsonFile("appsettings.json", false, true).
                Build();

// Using ContainerBuilder from Autofac
var cb = new ContainerBuilder();
var container = cb.Build();

ILifetimeScope _lifetimeScope = container.BeginLifetimeScope(builder => {
    // injecting core project
    CoreContainer.Bind(builder);
    // injecting configuration
    builder.RegisterInstance(configuration).As<IConfiguration>();
});
// END BASIC SETUP



Console.WriteLine("Starting simulator");
var pool = new BatteryPool();
// setup a simple servicebus event queue (no topic, no fanout)
var powerReaderEventService = new PowerReaderEventService(configuration);
var source = new PowerCommandSource(powerReaderEventService);
var logger = new CsvLogger(pool, source);


// set a LoadBalancer in the callback
var lb = new LoadBalancer(pool);
source.SetLoadBalancer(lb.TryGreedyBalance);


Console.WriteLine("Press enter to terminate");
Console.ReadLine();