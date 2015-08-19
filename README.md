WHA Tech Challenge

    Assumption:
    
    1)From the requirement I am not clear if I am allowed to move the CSV file's data into a database, hence I am using CSV as my Data source. 
    2)For Simplicity, I am using a CSV loader to load CSV into a c# object.
      In Scope
      1)  MVVM Framework
      2)  Local Service
      3)  Unit Test
      4)  Unity Container
      5)  minimum comments (due to time constraint)
    
      Not In Scope
      1)  UX design 
      2)  Composit Framework due to time constraint
      3)  WCF/Rest API Service for backend
      4)  Logging due to time constraint

    Analysis of the requirement
      FOR SETTLED DEAL
      For Each Customer
      #Identify  "WinningAtUnusalRateCustomer" = (Count(win) / total Bets) * 100 Where Win > 0 e.g = (7/10) * 100 = 70%
      #Calculate "AverageStake =  Avg(Stake)" 

    FOR USETTLED DEAL
    For each customer
    Identify High risk characteristics
  
      1) Highlight All customer  where WinningAtUnusalRateCustomer = true as Risky
      2) for each stake for the customer 
          if (Stake >=  10 * AverageStake) Then highlight as unusual
      3) for each stake for the customer 
          if (Stake >=  30 * AverageStake) Then highlight as Highly unusual
      4)  for each win for the customer 
           if(ToWin >= 1000) Then highlight as Risky
  
      Instruction
      1)  Ensure App.config is changed to point CSV files.
      2)  Ensure application downloads unity DLLs from github,package.config is part of the solution.
      3)  Solution is divided into
          a) Risk.Clinet (UI)
          b) Risk.Model (Model for UI)
          c) Risk.Service (Service Layer)
          d) Risk.Test(Unit Test)
      4)  Runnning application
        a) Application has only 1 view (RiskAnalyser)
        b) Applicaiton when loaded loads entire betting data (This is done asssuming datasource is CSV file) 
        c) Once betting data is loaded, user is presented with settled betting history by default. 
        d) User can navigate between Settled bet and UnSettled bet using Menu option on the top of the page (Betting).
        e) User can filter followings bets by using Second Menu option(Risky Bets) by clicking sub menus
            Winning At Unusal Rate
            Unusual Stake Bet
            Highly Unusual Stake Bet
            Big Win Bet
  
        f)  While user navigates between menu and sub menu, user is presented with text information directly below menu op

