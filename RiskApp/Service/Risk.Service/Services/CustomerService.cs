using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Risk.Model;
using Risk.Service.Repositories;
using Risk.Service.RiskPolicy;

namespace Risk.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBetRepository m_repository;


        public CustomerService(IBetRepository repository)
        {
            m_repository = repository;
        }

        
        
        private List<CustomerBet> m_CustomerSettledBets;
        public List<CustomerBet> CustomerSettledBets
        {
            get
            {
                if (m_CustomerSettledBets == null)
                    Init();
                return m_CustomerSettledBets;
            }
        }
        
        private List<CustomerBet> m_CustomerUnSettledBets;
        public List<CustomerBet> CustomerUnSettledBets
        {
            get
            {
                if (m_CustomerUnSettledBets == null)
                    Init();
                return m_CustomerUnSettledBets;
            }
        }

       
        
        public void Init()
        {   
            m_CustomerSettledBets = new List<CustomerBet>();
            m_CustomerUnSettledBets = new List<CustomerBet>();

            
            //Load AllUnique Customers from the bet history
            var customerIDs = m_repository.GetUniqueCustomerID();

            var settledRiskPolicies = new List<IRiskPolicy> { new WinningAtUnusalRatePolicy() };
            var undsettledRiskPolicies = new List<IRiskPolicy> { new BigWinRiskPolicy(), new HighlyUnusalStakePolicy(), new UnusalStakePolicy() };

            foreach (var customerID in customerIDs)
            {
                //Add Settled Bet for the given customer
                var settledBet = new CustomerBet();
                settledBet.Bet = new List<Bet>(m_repository.GetSettledBetForCustomer(customerID));
                settledBet.AverageBettingStake = settledBet.Bet.Average(a=>a.Stake);
                m_CustomerSettledBets.Add(settledBet);
                
                //Run Policy on settled Bet
                settledRiskPolicies.ForEach(policy => policy.Run(settledBet));

                //Add Unsettled Bets for the given Customer
                var unSettledBet = new CustomerBet();
                unSettledBet.Bet = new List<Bet>(m_repository.GetUnSettledBetForCustomer(customerID));
                unSettledBet.AverageBettingStake = settledBet.AverageBettingStake;
                m_CustomerUnSettledBets.Add(unSettledBet);

                //Run policy on unsettled Bet
                undsettledRiskPolicies.ForEach(policy => policy.Run(unSettledBet));

                //Mark all these customer as Risky as they have risky history
                unSettledBet.Bet.ForEach(x => x.WinningAtUnusalRate = settledBet.Bet.First().WinningAtUnusalRate);

            }
        }

       
        


    }
}