-> start

=== start ===
Please help me. My name is Samantha Reyes, and I'm in serious trouble!
    + [You're one of the hikers that went missing! What happened?]
        -> resOne("I was backpacking with my friend Emily at Whispering Pines State Park. All of a sudden, she fell ill and collapsed face-first onto the trail. I left to go find help, but I've been lost ever since and I have no idea where she is.")
    + [Are you okay?]
        -> resOne("No I need help. I am lost. I was hiking with my friend Emily and she had an accident where she couldn't move her body. I left to go get help but I've been stranded in the woods ever since. I have no idea where she is at.")

=== resOne(response) ===
{response}
    + [It's okay we will find you help. Follow me down the road. We have a cabin.]
        -> resTwo("Okay, but I am feeling a bit sick right now. I don't think I can walk much farther.")
    + [How strange... My friend Marcus had a similar injury. I can try and help you.]
        -> resTwo("Okay, but I am feeling a bit sick right now. I don't think I can walk much farther.")

=== resTwo(response) ===
{response}
    + [C'mon, it's not too far, and we will get out of here in the morning.]
        -> resThree("No, I don't think you understand.")

=== resThree(response) ===
{response}
    + [Continue]
        -> lastRes("There is no way out of here...")

=== lastRes(response) ===
{response}

-> END
