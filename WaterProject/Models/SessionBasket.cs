﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WaterProject.Infrastructure;

namespace WaterProject.Models
{
    public class SessionBasket : Basket
    {

        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // This goes out and looks in the session for a thing called basket. If there isnt, a new session basket is created. 
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;
            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set;}


        public override void AddItem(Project proj, int qty)
        {
            base.AddItem(proj, qty);
            Session.SetJson("Basket", this); // This is this specific instance of the class
        }

        public override void RemoveItem(Project proj)
        {
            base.RemoveItem(proj);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
