

+ Approach
++ Every interaction with system state is via a transaction.
++ Every transaction has four components: Input, Validation, Logic, Output.
++ Every txn is executed by a Transaction Manager.

+ Benefits
++ Consistency...
+++ ...of development
+++ ...at run time  (logging, validation, exception handling)
++ Testability
+++ Simple to define inputs and expected outputs and test against a transaction.
++ Security
+++ Authorisation of complex resources can be reduced to simply access to transactions.