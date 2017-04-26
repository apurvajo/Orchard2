﻿using Microsoft.AspNetCore.Server.IntegrationTesting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Logging;

namespace Orchard.Functional.Tests
{
    public static class ApplicationDeployerFactoryHelpers
    {
        public static IApplicationDeployer Create()
        {
            var deploymentParameters = new DeploymentParameters(
                EnvironmentHelpers.GetApplicationPath(), ServerType.Kestrel, RuntimeFlavor.CoreClr, RuntimeArchitecture.x64)
            {
                EnvironmentName = "Development",
                ServerConfigTemplateContent = null,
                SiteName = "Orchard Core Web",
                PublishApplicationBeforeDeployment = false,
                PreservePublishedApplicationForDebugging = false,
                TargetFramework = "netcoreapp1.1",
                Configuration = EnvironmentHelpers.GetCurrentBuildConfiguration(),
                ApplicationType = ApplicationType.Portable,
                AdditionalPublishParameters = " -r " + RuntimeEnvironment.GetRuntimeIdentifier(),
                UserAdditionalCleanup = parameters => {

                }
            };
            
            return ApplicationDeployerFactory.Create(deploymentParameters, new LoggerFactory());
        }
    }
}