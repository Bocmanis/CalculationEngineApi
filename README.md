# CalculationEngineApi

For the sake of simplicity the solution
* has no authorization/authentication
* doesnt have serverside localization, frontend could implement it by using product codes
* very little error management as it would never ever break ;)
* unit count 1-50 is hardcoded and not configurable

Application is divided in layers
* Core holds models and interfaces
* Data access layer implements access to database with repository ish pattern
* Logic uses DAL and parameters to do calculations
* API  handles application and exposes access points

There are unit tests written for Logic.


