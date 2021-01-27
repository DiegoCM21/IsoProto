
public class AttributeModifier
{
    // Value of the modifier
    public readonly float value;
    // Type of modifier. Can be additive (+X value) or multiplicative (+ % of value)
    public readonly AttModType modType;

    public AttributeModifier(float val, AttModType mType)
    {
        this.value = val;
        this.modType = mType;
    }
}
