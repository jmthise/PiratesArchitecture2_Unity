Okay so, i am trying to design a code architecture for my Unity game. There are a few ideas that i have and a few requirements to take into consideration.

The main idea is to control Units from the Player. For this, i would like to introduce a system of commands. That means the Player would send commands to the Unit.

We can thing of it as a controlled and a controlled. The controller would send commands to the controlled. The controlled would then handle the command.

While this looks like the command pattern, i actually don't want the command itself to contain logic. The command should only contain data about the command but that's it. This is in order to have the Player as decoupled as possible from the Unit. The unit doesn't care about the player, it just receives command. And the Player doesn't care about which unit it controls, it just sends commands.

To do so, we need a way to inform the Player of which commands the unit can receive at any given time. But while it is good to tell the player which kind of command the Unit can receive, the player actually need a way to know what kind of "manipulation" is needed for that command to be executed. For example, we might want a right click on the ground to get the position. Or we might need just a key press. Or we might need some things more complex like clicking on some buttons on 3D UI. I still don't know what would be the right approach to match the correct "manipulation" to the commands.

An other idea of this architecture is that the unit would receive commands and along with those commands, would receive the identity of the sender. The goal of having that identity is to allow the unit to have different level of control or "authority". We might have different players that have different levels of authority over an unit. For example, the player "owning" the unit would have full control over the unit, while the teammates of the player might have some sort of control over the unit but a bit restricted. Player of the opposite team would have no control over the unit.

An other goal of that system is to be able to have not only players controlling an unit, but we might have a script with logic that controls the unit. The goal of this is to have the same architecture for npc or controlled units. This would also allow to have some sort of automatic control over an unit for when the player is not controlling it.

That means Units would be "controlled" by receiving commands by a "controller" that gives it's identity along the command. Player or AI would be controllers.

In terms of logic, the Unit (or controlled) would pass the commands to a handler that would be responsible for creating the right "Processor" for any given command. Think of a handler as a factory for processors. Processors would contain the necessary logic in response to a command. It means that handlers would be aware of the sub-systems of the unit (like movement system, inventory system, attributes system, health system, etc) and would know exactly how to handle a command in regard to those sub-systems.


To recap : A controller retreives the list of available actions the unit can perform. Based on these actions, the controller can perform manipulations (key press, click in UI etc). These manipulations create commands with the necessary data. The command is sent to the unit along with the controller's identity. The Unit receives the commands. The authority system of the unit checks if the controller has the right to send that command. If positive, the unit 
Below is a list of the goals of the game and what this architecture need to take into account.

- Units need to be able to move in two distinct ways. Direct or indirect movement. Direct movement is directly reactive to input. For example move with wasd keys, rotate the direction of the unit based on the direction of the player camera, strafe, jump etc. Indirect movement is movement using intermediary systems like pathfinding. Indirect movement commands would be commands that request the unit to move to a certain target position and the unit would need to figure out by itself how to move to the position.
- We need the player to be able to select multiple units and assign the same command to all of them. But while the command seems to be the same, we might want to have specific behaviours coming along with it. For example, we would want them to move by respecting a certain "formation" pattern. If the player asks them to move to a certain position, they would need to move to that position while respecting the formation pattern and so the actual position of the "single" unit might not be exactly the position requested by the player, we would want the center of the formation to be on the position but the unit individual positions would be offset.
- We could have some things like request a group of units to use a canon. But each one would use a different slot of the canon. There might also be more units than the number of available slots and so some of those units would not just move to there and not use the slot.
- We need to be able to queue commands. That means a player could shift right click on the ground to queue the action. That would mean the unit would perform the action only when the ongoing action is finished.
- Since there are actions that are immediate and some actions that take some time to perform, we need to also take this into account. A direct movement action would be immediate, while a move to position would not be immediate. Also, imagine the case where we request an unit to use a canon, the unit would first need to move to the vicinity of the canon and then use it. So one command would in fact queue some actions.
- For multiplayer, we need to know when and how to sync things. Some things need to be client-predicted with server reconciliation while some other might not.
- We can introduce "Jobs". Jobs are not immediate. Jobs are created to respond to commands. Jobs are being executed until completion. We could architecture this in such a way that a command creates a job. The job then execute the necessary processor upon completion of the job.


Things to think about for the game :

- Ingame "lobal" chat
- Account creation / Authentication
- Friends system
- Friends list UI
- Friends messaging system + UI

- Options / Preferences menu
- Key bindings
- Graphics settings

Player
    - Selection
    - Input management
    - Create action for unit

- Command / Action / Job queuing (additive or not)

- Client prediction / Server reconciliation

- Abilities
- Ability manipulation mode (point and click, button press, vector targetting, targetting at range)...

Unit
    - Command
    - Action
    - Action Notifier
    - Taking command
    - Command authority
    - Command to Job
    - Job stack execution
    - Job to processor
    - Movement system
    - Inventory system
    - Equipment
    - Attributes
    - Abilities
    - Health / other ressources
    - Animation
    - Model/rendering
    - State

- Unit third person controller with controls (rotate camera rotates direction of unit)

- Selectable object (unit/controllable)
- Selection collider
- Selection rendering for player (locally)
- Selectable or not depending on ownership / authority

- Rendering path from pathfinding
- Move command position sprite animation
- Grouping units
- Selected unit(s) UI
- Unit window
    - Attribute list and values
    - Equipment
    - Inventory
- Unit name

- Unit groups
- Moving as a group
- Formations of units
- Moving while maintaining formation

- Manipulation of target formation / direction of units / number of lines

- Unit stance (auto attack, hold position, etc)

- Automatic assignment of tasks for units

- Player team
- Controller identity
- Unit control authority and layers

- Spawning unit
- Spawn points
- Spawn on cursor position


- Pathfinding
    - Data structure
    - Algorythms
        - AStar
        - ThetaStar
    - NavMesh generation
    - Mesh to NavMesh
    - Line of sight
    - Raycast on NavMesh

- Ship
    - Buoyancy
    - Procedural generation
        - Hull mesh generation
            - Nurbs
            - BMesh
    - Customizer

- World
    - Ocean
        - Get water height
        - FFT
    - Wind
    - Islands


- Items

- Auction house
- Merchants
- Shipyard

- Drag and drop inventory

- Pickup items

- Interact with objects (door)
- "use" object
- Object slots and interactors
    - Canons
    - Manipulating sails or ropes

- Unit abilities
    - Ability types
        - Using an item
        - Using ressources (mana, energy, etc)

- Unit attributes limits (min and max etc)

- Unit AI Algorythm

- Unit hunger
- Unit fatigue / energy
- Unit health
- Unit strength

- Unit weight

- Item / object weight

- Item inventory size / weight
- Item stacking
- Division of item stacks

- Consumable items (food, medecine etc)

- Unit equipment
    - Weapons
    - Clothes

- Pathfinding on ships
- Connecting navmeshes
- Parenting of units to moving object for movement in local space

- Ship inventory and cargo
- Ship compartiments
- Ship edition of rooms (walls)
- Ship edition of equipment

- Ship reparis
- Ship maintenance (cleaning)
- Perishable 
- Unit sickness
- Unit buff / debuffs / consumable effects