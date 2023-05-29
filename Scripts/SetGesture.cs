using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class SetGesture : MonoBehaviour
{
    DatabaseReference reference;
    FirebaseDatabase firebaseDatabase;

    void Start()
    {
        // initializing database reference
        Debug.Log("No Problem");
        firebaseDatabase = FirebaseDatabase.GetInstance("https://aivrtest-default-rtdb.firebaseio.com/");
        reference = firebaseDatabase.RootReference;
        Debug.Log(reference);
    }

    public void Hold()
    {
        reference.Child("bool_Gesture").SetValueAsync("isHold");
    }

    public void Move()
    {
        reference.Child("bool_Gesture").SetValueAsync("isMove");
    }

    public void Jump()
    {
        reference.Child("bool_Gesture").SetValueAsync("isJump");
    }

}
