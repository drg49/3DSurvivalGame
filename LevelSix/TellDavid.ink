-> start

=== start ===
Hey, everything good out there?
    + [No! I can't believe what I just saw with my own eyes. Grab the gun and lock the door.]
        -> resOne("What happened?")

=== resOne(response) ===
{response}
    + [At first I found one of the missing hikers, but then it was a demon that ended up chasing me!]
        -> resTwo("Are you joking?")
 
=== resTwo(response) ===
{response}
    + [No I am not joking, and I am not crazy. This was for real. We need to stay inside here.]
        -> resThree("Okay, fine... but I'm exhausted, and I'm not staying up all night watching for some demon you might've imagined.")

=== resThree(response) ===
{response}
    + [You and Marcus never seem to believe the things I see. Just wait until it's too late...]
        -> resFour("Yeah okay, well... Go to sleep. You can take the couch, I'll get some blankets out of the dresser and make a bed on the floor. If you have any issues just wake me up. But we're spending the night here for a reason, we need to rest so we can get back down to basecamp tomorrow and find help for Marcus.")

=== resFour(response) ===
{response}

-> END
