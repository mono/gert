.assembly bug {}

.class interface public abstract IA
{
  .method public abstract virtual 
          instance void  methodA() cil managed
  {
  }
}

.class interface public abstract IA2
       implements IA
{
  .method public abstract virtual 
          instance void  methodA2() cil managed
  {
  }
}

.class interface public abstract IB
       implements IA2
       // , IA
{
  .method public abstract virtual 
          instance void  methodB() cil managed
  {
  }
}
