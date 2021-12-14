# FoxyBank

Welcome to the Foxy bank ReadMe-file.

## The structure
We started the project by creating an uml and brainstormed about the structure. the uml is linked below and has been updated throughout the project.
The program consists of a main class which is the Bankclass where we put most of the logic and methods.
It consists of Lists and Dictionaries that holds the information of the persons in the program, bankaccounts in the bank and the different currencies in the bankaccounts.
We assigned a unique ID to the persons and bankaccounts and used the ID as a key in the dictionary to identify which person or bankaccount is being used. 

We made a parentclass named Person that contains the information such as ID, Name and password and two derived classes named Admin and User.
The Admin has authority to change the currency and create new users.
The User can create different bankaccounts (saving, loan, foreign and personal), deposit money, transfer money between users and accounts, take loans, display all accounts and view a log of every action.
We made a Bankaccountlist that holds the different accounts for the user and used a dictionary here aswell to identify which account was which when doing transfers, deposits etc.





 



UML Chart: https://lucid.app/lucidchart/74f31ecc-f59d-4535-be4f-cabeeb18024b/edit?invitationId=inv_f4805ecb-744e-4b8e-81c2-011f1ecf531c
