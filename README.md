# AircraftAPI

Changed item#, AircraftId, Aircraft(repair)Id all to Id, in order to use CLI to scaffold Controller.
As a result, can only make one post per

Use AircraftRepair as a distinct DAO rather than using id + List<Repair>.
  
refactor service logic conditionals into separate methods for easier unit testing.

remove dbcontext as it is unused

dbcontext is further exploration of entity framework

