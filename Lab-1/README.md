## 1. DRY (Don't Repeat Yourself)

The Base Classes [AnimalBase](./Zoo/ZooLib/Animals/AnimalBase.cs) and [EmployeeBase](./Zoo/ZooLib/Employees/EmployeeBase.cs) encapsulate common behavior and properties that would otherwise be duplicated across multiple classes.
There are also Interface Abstractions, such as [IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs), [IEmployee](./Zoo/ZooLib/Employees/IEmployee.cs), and [IEnclosure](./Zoo/ZooLib/Enclosures/IEnclosure.cs) which define shared contracts that eliminate the need for duplicating method signatures. 
We have a lot of Helper Methods that consolidate repeated logic. For example, the [CanHostAnimal](./Zoo/ZooLib/Enclosures/Enclosure.cs#L27-L30) method in the [Enclosure](./Zoo/ZooLib/Enclosures/Enclosure.cs) class centralizes the logic for checking if an animal can be added. 
The [CanHandleAnimal](./Zoo/ZooLib/Employees/EmployeeBase.cs#L43-L46) method in [EmployeeBase](./Zoo/ZooLib/Employees/EmployeeBase.cs) provides a consistent way to check role-based permissions. 
Also exists Shared Validation Logic which appears in the [IFoodRequirement](./Zoo/ZooLib/Food/FoodRequirements/IFoodRequirement.cs) implementations where the [CanEat](./Zoo/ZooLib/Food/FoodRequirements/IFoodRequirement.cs#L13) method follows a similar pattern across different animal types.

## 2. KISS (Keep It Simple, Stupid)

There are Clear Naming Conventions that make the purpose of classes, methods, and properties immediately apparent (for example, [CleanEnclosures()](./Zoo/ZooLib/Employees/Roles/Zookeeper.cs#L43-L53), [FeedAnimals()](./Zoo/ZooLib/Employees/Roles/Zookeeper.cs#L24-L41), [AddResponsibleEnclosure()](./Zoo/ZooLib/Employees/Roles/Zookeeper.cs#L18-L22)). 
Responsibility Separation through specialized manager classes ([AnimalManager](./Zoo/ZooLib/ZooManagement/AnimalManager.cs), [EmployeeManager](./Zoo/ZooLib/ZooManagement/EmployeeManager.cs), etc.) that keep individual class implementations simple. 
There are Simple Algorithms with linear complexity, such as in [GetAllAnimals()](./Zoo/ZooLib/ZooManagement/AnimalManager.cs#L30-L33), [GetEmployeesByRole()](./Zoo/ZooLib/ZooManagement/EmployeeManager.cs#L27-L30), and other similar methods.

## 3. SOLID Principles

### Single Responsibility Principle (SRP)

Classes in the ZooLib system are well-focused on specific responsibilities.

Animal Classes ([Bird](./Zoo/ZooLib/Animals/Bird.cs), [Mammal](./Zoo/ZooLib/Animals/Mammal.cs)) focus solely on animal behaviors and characteristics. 
Role-specific Employee Classes ([Zookeeper](./Zoo/ZooLib/Employees/Roles/Zookeeper.cs), [Veterinarian](./Zoo/ZooLib/Employees/Roles/Veterinarian.cs)) implement only the behavior relevant to their role. 
Manager Classes have distinct areas of responsibility: [AnimalManager](./Zoo/ZooLib/ZooManagement/AnimalManager.cs) handles only animal-related operations, [EmployeeManager](./Zoo/ZooLib/ZooManagement/EmployeeManager.cs) manages only employee-related actions, [EnclosureManager](./Zoo/ZooLib/ZooManagement/EnclosureManager.cs) deals specifically with enclosure management, [FoodManager](./Zoo/ZooLib/ZooManagement/FoodManager.cs) focuses on food inventory management.
Health-related Classes like [HealthRecord](./Zoo/ZooLib/HealthInfo/HealthRecord.cs) and various [Vaccine](./Zoo/ZooLib/HealthInfo/Vaccines/Vaccine.cs) implementations handle only health-related concerns.

### Open/Closed Principle (OCP)

The codebase is designed to be extended without modifying existing code.

Interface-based Design allows for new implementations of [IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs), [IEmployee](./Zoo/ZooLib/Employees/IEmployee.cs), [IEnclosure](./Zoo/ZooLib/Enclosures/IEnclosure.cs), etc., without changing existing code. 
Inheritance Hierarchies like [AnimalBase](./Zoo/ZooLib/Animals/AnimalBase.cs) with derived [Bird](./Zoo/ZooLib/Animals/Bird.cs) and [Mammal](./Zoo/ZooLib/Animals/Mammal.cs) classes enable extension through new animal types. 
Enclosure Specialization through classes like [AviaryEnclosure](./Zoo/ZooLib/Enclosures/AviaryEnclosure.cs) and [TerrestrialEnclosure](./Zoo/ZooLib/Enclosures/TerrestrialEnclosure.cs) that extend the base [Enclosure](./Zoo/ZooLib/Enclosures/Enclosure.cs) class. 
Role-based System allows new employee roles to be added by implementing the [IEmployeeRole](./Zoo/ZooLib/Employees/IEmployeeRole.cs) interface.

### Liskov Substitution Principle (LSP)

Animal Hierarchy ensures that derived classes like [Bird](./Zoo/ZooLib/Animals/Bird.cs) and [Mammal](./Zoo/ZooLib/Animals/Mammal.cs) can be used wherever [IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs) is expected. 
Employee System allows any [IEmployee](./Zoo/ZooLib/Employees/IEmployee.cs) implementation to be used interchangeably. 
Enclosure Types ([AviaryEnclosure](./Zoo/ZooLib/Enclosures/AviaryEnclosure.cs), [TerrestrialEnclosure](./Zoo/ZooLib/Enclosures/TerrestrialEnclosure.cs)) maintain the contract of the [IEnclosure](./Zoo/ZooLib/Enclosures/IEnclosure.cs) interface. 
Food Requirements for different animal types correctly implement the [IFoodRequirement](./Zoo/ZooLib/Food/FoodRequirements/IFoodRequirement.cs) interface.

### Interface Segregation Principle (ISP)

Animal Interfaces are minimal, with specific animal types implementing only relevant behaviors. Employee Interfaces define only essential methods, with role-specific behaviors handled through composition with [IEmployeeRole](./Zoo/ZooLib/Employees/IEmployeeRole.cs). 
Food-related Interfaces like [IFood](./Zoo/ZooLib/Food/IFood.cs) and [IFoodRequirement](./Zoo/ZooLib/Food/FoodRequirements/IFoodRequirement.cs) contain only methods relevant to their purpose.

### Dependency Inversion Principle (DIP)

The code consistently depends on abstractions rather than concrete implementations.

Manager Classes work with interface types ([IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs), [IEmployee](./Zoo/ZooLib/Employees/IEmployee.cs), [IEnclosure](./Zoo/ZooLib/Enclosures/IEnclosure.cs)) rather than concrete classes. 
Employee Classes depend on the [IEmployeeRole](./Zoo/ZooLib/Employees/IEmployeeRole.cs) abstraction rather than specific role implementations. Animal Handling Logic in [Zookeeper](./Zoo/ZooLib/Employees/Roles/Zookeeper.cs) and [Veterinarian](./Zoo/ZooLib/Employees/Roles/Veterinarian.cs) classes operates on the [IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs) interface. 
Food System works with [IFood](./Zoo/ZooLib/Food/IFood.cs) and [IFoodRequirement](./Zoo/ZooLib/Food/FoodRequirements/IFoodRequirement.cs) abstractions.

## 4. YAGNI (You Aren't Gonna Need It)

The codebase avoids unnecessary complexity by implementing only essential functionality.

There are Focused Class Responsibilities without extraneous methods or properties. Minimal Validation Logic that covers only essential business rules. Basic Reporting Methods like [PrintZooStatus()](./Zoo/ZooLib/ZooManagement/Zoo.cs#L53-L72) that provide necessary information without excessive functionality.

## 5. Composition Over Inheritance

The codebase effectively uses composition to create flexible and maintainable relationships.

Employee-Role Relationship uses composition IEmployeeRole rather than creating a deep inheritance hierarchy. Animal-Enclosure Relationship is managed through composition IEnclosure. 
Health Record System composes with both animals and employees rather than being inherited. Food Requirements are composed with animals rather than being part of the inheritance hierarchy.

## 6. Program to Interfaces, not Implementations

All manager classes operate on interface types ([IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs), [IEmployee](./Zoo/ZooLib/Employees/IEmployee.cs), [IEnclosure](./Zoo/ZooLib/Enclosures/IEnclosure.cs), [IFood](./Zoo/ZooLib/Food/IFood.cs)). 
Enclosure management uses [IAnimal](./Zoo/ZooLib/Animals/IAnimal.cs) interface for all animal-related operations. Employee operations depend on the [IEmployeeRole](./Zoo/ZooLib/Employees/IEmployeeRole.cs) interface. [Zoo](./Zoo/ZooLib/ZooManagement/Zoo.cs) class orchestrates interactions between systems through their interfaces.

## 7. Fail Fast

The system implements several mechanisms to detect errors early.

Validation in Animal Handling prevents incompatible animals from being added to enclosures. Role-based Permission Checks in [CanHandleAnimal](./Zoo/ZooLib/Employees/IEmployee.cs#L18) prevent unauthorized animal handling. 
Exception Throwing in methods like [Feed()](./Zoo/ZooLib/Animals/IAnimal.cs#L23) when incompatible food is provided. Capacity Checks when adding animals to enclosures. Validation for Vaccine Administration through the [IsApplicableTo](./Zoo/ZooLib/HealthInfo/Vaccines/IVaccine.cs#L17) check.
