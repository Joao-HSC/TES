﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder
    {
        public static IHost BuildTradingEngineServer()
        => Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            // Configs
            services.AddOptions();
            services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

            // Singleton objects
            services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

            // Hosted service
            services.AddHostedService<TradingEngineServer>();
     
        }).Build();
    }
}
