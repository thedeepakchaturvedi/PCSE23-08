using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class GestureControl : MonoBehaviour
{
    //public TextMeshProUGUI txtField;
    public Movement movement;

    DatabaseReference reference;
    FirebaseDatabase firebaseDatabase;
    string curr_gesture = "isHold";

    public GroundCheck groundCheck; 

    void Start()
    {
        // initializing database reference
        Debug.Log("No Problem");
        firebaseDatabase = FirebaseDatabase.GetInstance("https://aivrtest-default-rtdb.firebaseio.com/");
        reference = firebaseDatabase.RootReference;
        Debug.Log(reference);

        reference.Child("bool_Gesture").SetValueAsync("isHold");

        firebaseDatabase
      .GetReference("bool_Gesture")
      .GetValueAsync().ContinueWithOnMainThread(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              curr_gesture = snapshot.Value.ToString();

          }
      });

        // onValue Changed
        firebaseDatabase
       .GetReference("bool_Gesture")
       .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        //txtField.text = "Gesture_Value : " + args.Snapshot.Value.ToString();
        Debug.Log(args.Snapshot);
        curr_gesture = args.Snapshot.Value.ToString();
    }


    void Update()
    {
       if(curr_gesture.Equals("isHold"))
        {
            Debug.Log("Holddddd");
            movement.isJump = false;
            movement.isMove = false;
            groundCheck._onGround = true;
        }
       else if(curr_gesture.Equals("isMove"))
        {
            Debug.Log("Moveeee");
            movement.isJump = false;
            movement.isMove = true;
            groundCheck._onGround = true;
        }
       else if(curr_gesture.Equals("isJump"))
        {
            Debug.Log("Jumpppp");
            movement.isJump = true;
            movement.isMove = false;
        }
    }
}
