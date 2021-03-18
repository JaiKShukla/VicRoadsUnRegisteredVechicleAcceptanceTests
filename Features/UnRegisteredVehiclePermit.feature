
@UnRegisteredVechilePermit
Feature: Verify the user can apply for unregistered vehicle permits
	As a vicroads user
	I want to apply for unregisted vehicle permits
	so that vehicle permits can be registered

Scenario Outline: Verify the user can apply for unregistered vehicle permits for Passenger Vehicle
	Given the user is on Unregistered Vehicle Permit application form
	 When the user registers the vehicle with these details
		| Vehicle Type   | Passenger Vehicle Type  | Address   | Permit Start Date | Permit Duration  | 
		| <vechicleType> | <passengerVechicleType> | <address> | <permitStartDate> | <permitDuration> | 
		#Then Calculated Fees for unregistered vehicle permits is <Fees>
	Then the user can proceed to Select Permit Type option
	Examples:  Passenger Vehicle iterations
		| vechicleType     | passengerVechicleType | address                                     | permitStartDate | permitDuration |
		| PassengerVehicle | Sedan                 | 61A BolingBroke Street Pascoe Vale Vic 3044 | today           | 1 day          |
		| PassengerVehicle | Station Wagon         | 61B BolingBroke Street Pascoe Vale Vic 3044 | today           | 2 days         |
		#|To Add more iterations here

Scenario Outline: Verify the user can apply for unregistered vehicle permits for Goods Carrying Vehicle
	Given the user is on Unregistered Vehicle Permit application form
	 When the user registers the vehicle with these details
		| Vehicle Type   | CarryingCapacity   | Address   | Permit Start Date | Permit Duration  |
		| <vechicleType> | <carryingCapacity> | <address> | <permitStartDate> | <permitDuration> |
		#Then Calculated Fees for unregistered vehicle permits is <Fees>
	Then the user can proceed to Select Permit Type option
	Examples: Goods Carrying Vehicle iterations
		| vechicleType         | carryingCapacity | address                                     | permitStartDate | permitDuration |
		| GoodsCarryingVehicle | 2 tonnes or less | 61A BolingBroke Street Pascoe Vale Vic 3044 | today           | 1 day          |
		#|To Add more iterations here

Scenario Outline: Verify the user can apply for unregistered vehicle permits for Prime Mover
	Given the user is on Unregistered Vehicle Permit application form
	 When the user registers the vehicle with these details
		| Vehicle Type   | Address   | Permit Start Date | Permit Duration  |
		| <vechicleType> | <address> | <permitStartDate> | <permitDuration> |
		#Then Calculated Fees for unregistered vehicle permits is <Fees>
	Then the user can proceed to Select Permit Type option
	Examples: Prime Mover iterations
		| vechicleType | address                                     | permitStartDate | permitDuration |
		| PrimeMover   | 61A BolingBroke Street Pascoe Vale Vic 3044 | today           | 2 days         |
		#|To Add more iterations here

Scenario Outline: Verify the user can apply for unregistered vehicle permits for Motor Cycle
	Given the user is on Unregistered Vehicle Permit application form
	 When the user registers the vehicle with these details
		| Vehicle Type   | EngineCapacity     | Address   | Permit Start Date | Permit Duration  |
		| <vechicleType> | <engineCapacity> | <address> | <permitStartDate> | <permitDuration> |
		#Then Calculated Fees for unregistered vehicle permits is <Fees>
	Then the user can proceed to Select Permit Type option
	Examples: GMotor Cycle iterations
		| vechicleType | engineCapacity  | address                                     | permitStartDate | permitDuration |
		| Motorcycle   | Less than 61 cc | 61A BolingBroke Street Pascoe Vale Vic 3044 | today           | 1 day          |
		#|To Add more iterations here

Scenario Outline: Verify the user can apply for unregistered vehicle permits for Trailer/Caravan
	Given the user is on Unregistered Vehicle Permit application form
	 When the user registers the vehicle with these details
		| Vehicle Type   | Address   | Permit Start Date | Permit Duration  |
		| <vechicleType> | <address> | <permitStartDate> | <permitDuration> |
		#Then Calculated Fees for unregistered vehicle permits is <Fees>
	Then the user can proceed to Select Permit Type option
	Examples: Trailer/Caravan iterations
		| vechicleType | address                                     | permitStartDate | permitDuration |
		| Trailer      | 61A BolingBroke Street Pascoe Vale Vic 3044 | today           | 1 day          |      
		#|To Add more iterations here