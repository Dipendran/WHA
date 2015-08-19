using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;

namespace Risk.Service.Managers
{
    public static class CSVLoaderManager
    {
        private static CSVData m_CSVData;
        public static CSVData CSVData
        {
            get { return m_CSVData; }
        }
        static CSVLoaderManager()
        {
            m_CSVData = new CSVData(); 
            m_CSVData.SettledBets =  GetSettleBets();
            m_CSVData.UnSettledBets = GetUnSettleBets();
        }
        
        private static List<Bet> GetSettleBets()
        {
            var bets = new List<Bet>();
            var filePath = ConfigurationManager.AppSettings["CSVFilePath"];
            var connectionString = String.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;""", filePath);
            using (var cn = new OleDbConnection(connectionString))
            {
                cn.Open();

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Settled.csv]";

                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        var Customer = reader.GetOrdinal("Customer");
                        var Event = reader.GetOrdinal("Event");
                        var Participant = reader.GetOrdinal("Participant");
                        var Stake = reader.GetOrdinal("Stake");
                        var Win = reader.GetOrdinal("Win");

                        foreach (DbDataRecord record in reader)
                        {

                            bets.Add(new Bet
                            {
                                CustomerId = record.GetInt32(Customer),
                                EventId = record.GetInt32(Event),
                                ParticipantId = record.GetInt32(Participant),
                                Stake = record.GetInt32(Stake),
                                Win = record.GetInt32(Win)
                            });
                        }
                    }
                }
            }
            return bets;
        }

        private static List<Bet> GetUnSettleBets()
        {
            var bets = new List<Bet>();
            var filePath = ConfigurationManager.AppSettings["CSVFilePath"];
            var connectionString = String.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;""", filePath);
            using (var cn = new OleDbConnection(connectionString))
            {
                cn.Open();

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Unsettled.csv]";

                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        var Customer = reader.GetOrdinal("Customer");
                        var Event = reader.GetOrdinal("Event");
                        var Participant = reader.GetOrdinal("Participant");
                        var Stake = reader.GetOrdinal("Stake");
                        var Win = reader.GetOrdinal("ToWin");

                        foreach (DbDataRecord record in reader)
                        {

                            bets.Add(new Bet
                            {
                                CustomerId = record.GetInt32(Customer),
                                EventId = record.GetInt32(Event),
                                ParticipantId = record.GetInt32(Participant),
                                Stake = record.GetInt32(Stake),
                                Win = record.GetInt32(Win)
                            });
                        }
                    }
                }
            }
            return bets;
        }

    }
}
