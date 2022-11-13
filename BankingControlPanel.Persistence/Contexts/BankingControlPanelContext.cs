﻿using BankingControlPanel.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Persistence.Contexts
{
    public class BankingControlPanelContext : IdentityDbContext
    {
        public BankingControlPanelContext(DbContextOptions options) : base(options)
        {

        }
/*        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }*/
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }
    }
}
 