internal interface IDamagable
{
    int HP { get; set; }
    void TakeDamage(int damage);
}