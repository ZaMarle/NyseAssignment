Nyse Programming Project
========================================

The Nyse Programming project is a windows client application built for viewing prices on the New York Stock Exchange.


Features

*Sql Server database
  -Stores the stock data
  
*Entity Framework Project
  -Access to the data from the database
  
*asp.Net Web Api Project
  -Exposes the data to a web server

*Wpf mvvm Project
  -Consumes the data from the web serve into a Windows client application

Installation
----------------------------------------

Requirements:

*Visual Studio 
*Sql Server
*Windows opperation system


Clone

*Clone this repo to your local machine using https://github.com/ZaMarle/NyseAssignment.git


Configuration

*Download the Nyse-db-script.zip
*Run the script to generate the database in Sql Server
*Open the cloned application
*Update the connection string in "DatabaseAccess => Nyse.Entities => App.config" to access your local Sql Server

