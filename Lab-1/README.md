## 1. DRY (Don't Repeat Yourself)

The Base Classes [AnimalBase](./ZooLib/Animals/AnimalBase.cs) and [EmployeeBase](./ZooLib/Employees/EmployeeBase.cs) encapsulate common behavior and properties that would otherwise be duplicated across multiple classes.
There are also Interface Abstractions, such as [IAnimal](./ZooLib/Animals/IAnimal.cs), [IEmployee](./ZooLib/Employees/IEmployee.cs), and [IEnclosure](./ZooLib/Employees/IEclosure.cs) which define shared contracts that eliminate the need for duplicating method signatures. 
We have a lot of Helper Methods that consolidate repeated logic. For example, the [CanHostAnimal](./ZooLib/Employees/Eclosure.cs#L27-L30) method in the [Enclosure](./ZooLib/Employees/Eclosure.cs) class centralizes the logic for checking if an animal can be added. 
The [CanHandleAnimal](./ZooLib/Employees/EmployeeBase.cs#L43-L46) method in [EmployeeBase](./ZooLib/Employees/EmployeeBase.cs) provides a consistent way to check role-based permissions. 
Also exists Shared Validation Logic which appears in the [IFoodRequirement](./ZooLib/Food/IFoodRequirements.cs) implementations where the [CanEat](./ZooLib/Food/FoodRequirements.cs#L13) method follows a similar pattern across different animal types.

## 2. KISS (Keep It Simple, Stupid)

There are Clear Naming Conventions that make the purpose of classes, methods, and properties immediately apparent (for example, [CleanEnclosures()](./ZooLib/Employees/Roles/Zookeeper.cs#L43-L53), [FeedAnimals()](./ZooLib/Employees/Roles/Zookeeper.cs#L24-L41), [AddResponsibleEnclosure()](./ZooLib/Employees/Roles/Zookeeper.cs#L18-L22)). 
Responsibility Separation through specialized manager classes ([AnimalManager](./ZooLib/ZooManagement/AnimalManager.cs), [EmployeeManager](./ZooLib/ZooManagement/EmployeeManager.cs), etc.) that keep individual class implementations simple. 
There are Simple Algorithms with linear complexity, such as in [GetAllAnimals()](./ZooLib/ZooManagement/AnimalManager.cs#L30-L33), [GetEmployeesByRole()](./ZooLib/ZooManagement/EmployeeManager.cs#L27-L30), and other similar methods.

## 3. SOLID Principles

### Single Responsibility Principle (SRP)

Classes in the ZooLib system are well-focused on specific responsibilities.

Animal Classes ([Bird](./ZooLib/Animals/Bird.cs), [Mammal](./ZooLib/Animals/Mammal.cs)) focus solely on animal behaviors and characteristics. 
Role-specific Employee Classes ([Zookeeper](./ZooLib/Employees/Roles/Zookeeper.cs), [Veterinarian](./ZooLib/Employees/Roles/Veterinarian.cs)) implement only the behavior relevant to their role. 
Manager Classes have distinct areas of responsibility: [AnimalManager](./ZooLib/ZooManagement/AnimalManager.cs) handles only animal-related operations, [EmployeeManager](./ZooLib/ZooManagement/EmployeeManager.cs) manages only employee-related actions, [EnclosureManager](./ZooLib/ZooManagement/EnclosureManager.cs) deals specifically with enclosure management, [FoodManager](./ZooLib/ZooManagement/FoodManager.cs) focuses on food inventory management.
Health-related Classes like [HealthRecord](./ZooLib/HealthInfo/HealthRecord.cs) and various [Vaccine](./ZooLib/HealthInfo/Vaccines/Vaccine.cs) implementations handle only health-related concerns.

### Open/Closed Principle (OCP)

The codebase is designed to be extended without modifying existing code.

Interface-based Design allows for new implementations of [IAnimal](./ZooLib/Animals/IAnimal.cs), [IEmployee](./ZooLib/Employees/IEmployee.cs), [IEnclosure](./ZooLib/Employees/IEclosure.cs), etc., without changing existing code. 
Inheritance Hierarchies like [AnimalBase](./ZooLib/Animals/AnimalBase.cs) with derived [Bird](./ZooLib/Animals/Bird.cs) and [Mammal](./ZooLib/Animals/Mammal.cs) classes enable extension through new animal types. 
Enclosure Specialization through classes like [AviaryEnclosure](./ZooLib/Enclosures/AviaryEnclosure.cs) and [TerrestrialEnclosure](./ZooLib/Enclosures/TerrestrialEnclosure.cs) that extend the base [Enclosure](./ZooLib/Employees/Eclosure.cs) class. 
Role-based System allows new employee roles to be added by implementing the [IEmployeeRole](./ZooLib/Employees/IEmployeeRole.cs) interface.

### Liskov Substitution Principle (LSP)

Animal Hierarchy ensures that derived classes like [Bird](./ZooLib/Animals/Bird.cs) and [Mammal](./ZooLib/Animals/Mammal.cs) can be used wherever [IAnimal](./ZooLib/Animals/IAnimal.cs) is expected. 
Employee System allows any [IEmployee](./ZooLib/Employees/IEmployee.cs) implementation to be used interchangeably. 
Enclosure Types ([AviaryEnclosure](./ZooLib/Enclosures/AviaryEnclosure.cs), [TerrestrialEnclosure](./ZooLib/Enclosures/TerrestrialEnclosure.cs)) maintain the contract of the [IEnclosure](./ZooLib/Employees/IEclosure.cs) interface. 
Food Requirements for different animal types correctly implement the [IFoodRequirement](./ZooLib/Food/IFoodRequirements.cs) interface.

### Interface Segregation Principle (ISP)

Animal Interfaces are minimal, with specific animal types implementing only relevant behaviors. Employee Interfaces define only essential methods, with role-specific behaviors handled through composition with [IEmployeeRole](./ZooLib/Employees/IEmployeeRole.cs). 
Food-related Interfaces like [IFood](./ZooLib/Food/IFood.cs) and [IFoodRequirement](./ZooLib/Food/IFoodRequirements.cs) contain only methods relevant to their purpose.

### Dependency Inversion Principle (DIP)

The code consistently depends on abstractions rather than concrete implementations.

Manager Classes work with interface types ([IAnimal](./ZooLib/Animals/IAnimal.cs), [IEmployee](./ZooLib/Employees/IEmployee.cs), [IEnclosure](./ZooLib/Employees/IEclosure.cs)) rather than concrete classes. 
Employee Classes depend on the [IEmployeeRole](./ZooLib/Employees/IEmployeeRole.cs) abstraction rather than specific role implementations. Animal Handling Logic in [Zookeeper](./ZooLib/Employees/Roles/Zookeeper.cs) and [Veterinarian](./ZooLib/Employees/Roles/Veterinarian.cs) classes operates on the [IAnimal](./ZooLib/Animals/IAnimal.cs) interface. 
Food System works with [IFood](./ZooLib/Food/IFood.cs) and [IFoodRequirement](./ZooLib/Food/IFoodRequirements.cs) abstractions.

## 4. YAGNI (You Aren't Gonna Need It)

The codebase avoids unnecessary complexity by implementing only essential functionality.

There are Focused Class Responsibilities without extraneous methods or properties. Minimal Validation Logic that covers only essential business rules. Basic Reporting Methods like [PrintZooStatus()](./ZooLib/ZooManagement/Zoo.cs#L53-L72) that provide necessary information without excessive functionality.

## 5. Composition Over Inheritance

The codebase effectively uses composition to create flexible and maintainable relationships.

Employee-Role Relationship uses composition IEmployeeRole rather than creating a deep inheritance hierarchy. Animal-Enclosure Relationship is managed through composition IEnclosure. 
Health Record System composes with both animals and employees rather than being inherited. Food Requirements are composed with animals rather than being part of the inheritance hierarchy.

## 6. Program to Interfaces, not Implementations

All manager classes operate on interface types ([IAnimal](./ZooLib/Animals/IAnimal.cs), [IEmployee](./ZooLib/Employees/IEmployee.cs), [IEnclosure](./ZooLib/Employees/IEclosure.cs), [IFood](./ZooLib/Food/IFood.cs)). 
Enclosure management uses [IAnimal](./ZooLib/Animals/IAnimal.cs) interface for all animal-related operations. Employee operations depend on the [IEmployeeRole](./ZooLib/Employees/IEmployeeRole.cs) interface. [Zoo](./ZooLib/ZooManagement/Zoo.cs) class orchestrates interactions between systems through their interfaces.

## 7. Fail Fast

The system implements several mechanisms to detect errors early.

Validation in Animal Handling prevents incompatible animals from being added to enclosures. Role-based Permission Checks in [CanHandleAnimal](./ZooLib/Employees/IEmployee.cs#L18) prevent unauthorized animal handling. 
Exception Throwing in methods like [Feed()](./ZooLib/Animals/IAnimal.cs#L23) when incompatible food is provided. Capacity Checks when adding animals to enclosures. Validation for Vaccine Administration through the [IsApplicableTo](./ZooLib/HealthInfo/Vaccines/IVaccine.cs#L17) check.
