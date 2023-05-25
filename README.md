# blue-gravity-interview

Documentation
Summary:
The system consists of several scripts that provide key functionalities such as buying and selling clothing, inventory management, the ability to equip and unequip clothing items, and a basic currency system that allows users to spend or earn coins through buying and selling clothes. The development of the system was carried out in several stages.
- Implementation of the Basic Triple C:
The first stage involved creating a Basic Triple C (Character, Camera, Controller) to enable the character to move within the game world effectively.
- Interaction with the Shopkeeper:
Next, interaction with the shopkeeper in the clothing store was implemented. To achieve this, an interface called IInteractable was created, which can be added to new non-playable characters (NPCs) to enable interactions with them.
- Item Storage System:
The inventory, equipped items, and stores are managed through the StorageItemsSystem script. This script provides the basic logic for item storage, including item input and output, item selection, and other functionalities. All other systems inherit from this script and add additional logic to perform specific actions in each case.
- Communication Management between Scripts:
An EventManager was implemented to facilitate communication between different systems in the game. This allowed for efficient and synchronized updates of the systems.
- Use of Scriptable Objects for Items:
Items in the game are created using a Scriptable Object called "ItemSO". This object serves as a template that contains the necessary information to define each item in a structured manner.
Personal Evaluation:
I am very pleased with the process and the final result. I believe there is room for improvement since I am not accustomed to working on such large systems in my day-to-day work. There is potential for further enhancements and making certain parts of the code more efficient.
 
