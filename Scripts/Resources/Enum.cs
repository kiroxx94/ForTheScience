///////////////////////////////////
//                               //
// This files contains all Enums //
//                               //
///////////////////////////////////


public enum MovingController { Path_Follower, Random_Move }         // use this to choice the option move
public enum MoveType { MoveTowards, Lerp };                         // Use this to choice the type of move 
public enum ActionController { Idle, Chase, Search, Move }          // use this to say the action of the entity 

public enum EventType { DialogManager };                                   // Use this to choice the type of the event
public enum Status { Pending, Running, Done };                      // Use this to choice a status for the event

public enum ItemType { Life, Energy, Money };                       // Use this to choice the type of an item


