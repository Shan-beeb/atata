﻿using System;
using System.Collections.Generic;

namespace Atata
{
    public class AtataBuildingContext
    {
        internal AtataBuildingContext()
        {
        }

        public List<IDriverFactory> DriverFactories { get; private set; } = new List<IDriverFactory>();

        public List<LogConsumerInfo> LogConsumers { get; private set; } = new List<LogConsumerInfo>();

        public List<IScreenshotConsumer> ScreenshotConsumers { get; private set; } = new List<IScreenshotConsumer>();

        public IDriverFactory DriverFactoryToUse { get; internal set; }

        /// <summary>
        /// Gets or sets the factory method of the test name.
        /// </summary>
        public Func<string> TestNameFactory { get; set; }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        public string BaseUrl { get; set; }

        public List<Action> CleanUpActions { get; private set; } = new List<Action>();

        /// <summary>
        /// Gets the retry timeout. The default value is 10 seconds.
        /// </summary>
        public TimeSpan RetryTimeout { get; internal set; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Gets the retry interval. The default value is 500 milliseconds.
        /// </summary>
        public TimeSpan RetryInterval { get; internal set; } = TimeSpan.FromSeconds(0.5);

        /// <summary>
        /// Gets or sets the type of the assertion exception. The default value is typeof(Atata.AssertionException).
        /// </summary>
        public Type AssertionExceptionType { get; set; } = typeof(AssertionException);
    }
}
