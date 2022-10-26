using Conduit;
using Conduit.Core.Services;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

var app = Startup.InitializeApp(args);
    app.Run();
