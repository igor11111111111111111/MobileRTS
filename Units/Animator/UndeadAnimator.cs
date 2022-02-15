 class UndeadAnimator : MeleeAnimator
{
    public void AnimationEventDeath()
    {
        Destroy(gameObject);
    }
}

