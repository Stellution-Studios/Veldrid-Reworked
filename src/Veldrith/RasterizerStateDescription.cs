using System;

namespace Veldrith;

/// <summary>
/// A <see cref="Pipeline" /> component describing the properties of the rasterizer.
/// </summary>
public struct RasterizerStateDescription : IEquatable<RasterizerStateDescription> {

    /// <summary>
    /// Controls which face will be culled.
    /// </summary>
    public FaceCullMode CullMode;

    /// <summary>
    /// Controls how the rasterizer fills polygons.
    /// </summary>
    public PolygonFillMode FillMode;

    /// <summary>
    /// Controls the winding order used to determine the front face of primitives.
    /// </summary>
    public FrontFace FrontFace;

    /// <summary>
    /// Controls whether depth clipping is enabled.
    /// </summary>
    public bool DepthClipEnabled;

    /// <summary>
    /// The constant depth bias applied to depth values.
    /// </summary>
    public int DepthBias;

    /// <summary>
    /// The slope-scaled depth bias applied to depth values.
    /// </summary>
    public float SlopeScaledDepthBias;

    /// <summary>
    /// The maximum depth bias value.
    /// </summary>
    public float DepthBiasClamp;

    /// <summary>
    /// Controls whether the scissor test is enabled.
    /// </summary>
    public bool ScissorTestEnabled;

    /// <summary>
    /// Initializes a new instance of the <see cref="RasterizerStateDescription" /> type.
    /// </summary>
    /// <param name="cullMode">The cull mode value used by this operation.</param>
    /// <param name="fillMode">The fill mode value used by this operation.</param>
    /// <param name="frontFace">The front face value used by this operation.</param>
    /// <param name="depthClipEnabled">The depth clip enabled value used by this operation.</param>
    /// <param name="scissorTestEnabled">The scissor test enabled value used by this operation.</param>
    /// <param name="depthBias">The constant depth bias applied to depth values.</param>
    /// <param name="slopeScaledDepthBias">The slope-scaled depth bias applied to depth values.</param>
    /// <param name="depthBiasClamp">The maximum depth bias value.</param>
    public RasterizerStateDescription(FaceCullMode cullMode, PolygonFillMode fillMode, FrontFace frontFace, bool depthClipEnabled, int depthBias, float slopeScaledDepthBias, float depthBiasClamp, bool scissorTestEnabled) {
        this.CullMode = cullMode;
        this.FillMode = fillMode;
        this.FrontFace = frontFace;
        this.DepthClipEnabled = depthClipEnabled;
        this.DepthBias = depthBias;
        this.SlopeScaledDepthBias = slopeScaledDepthBias;
        this.DepthBiasClamp = depthBiasClamp;
        this.ScissorTestEnabled = scissorTestEnabled;
    }

    /// <summary>
    /// Defines the predefined value exposed by <c>DEFAULT</c>.
    /// </summary>
    public static readonly RasterizerStateDescription DEFAULT = new() {
        CullMode = FaceCullMode.Back,
        FillMode = PolygonFillMode.Solid,
        FrontFace = FrontFace.Clockwise,
        DepthClipEnabled = true,
        DepthBias = 0,
        SlopeScaledDepthBias = 0.0F,
        DepthBiasClamp = 0.0F,
        ScissorTestEnabled = false
    };

    /// <summary>
    /// Defines the predefined value exposed by <c>CULL_NONE</c>.
    /// </summary>
    public static readonly RasterizerStateDescription CULL_NONE = new() {
        CullMode = FaceCullMode.None,
        FillMode = PolygonFillMode.Solid,
        FrontFace = FrontFace.Clockwise,
        DepthClipEnabled = true,
        DepthBias = 0,
        SlopeScaledDepthBias = 0.0F,
        DepthBiasClamp = 0.0F,
        ScissorTestEnabled = false
    };

    /// <summary>
    /// Determines whether this instance is equal to the specified value.
    /// </summary>
    /// <param name="other">The value to compare against.</param>
    /// <returns><see langword="true" /> if the operation succeeds; otherwise, <see langword="false" />.</returns>
    public bool Equals(RasterizerStateDescription other) {
        return this.CullMode == other.CullMode
               && this.FillMode == other.FillMode
               && this.FrontFace == other.FrontFace
               && this.DepthClipEnabled.Equals(other.DepthClipEnabled)
               && this.DepthBias == other.DepthBias
               && this.SlopeScaledDepthBias.Equals(other.SlopeScaledDepthBias)
               && this.DepthBiasClamp.Equals(other.DepthBiasClamp)
               && this.ScissorTestEnabled.Equals(other.ScissorTestEnabled);
    }

    /// <summary>
    /// Computes a hash code for this instance.
    /// </summary>
    /// <returns>The value produced by this operation.</returns>
    public override int GetHashCode() {
        return HashHelper.Combine((int)this.CullMode, (int)this.FillMode, (int)this.FrontFace, this.DepthClipEnabled.GetHashCode(), this.DepthBias, this.SlopeScaledDepthBias.GetHashCode(), this.DepthBiasClamp.GetHashCode(), this.ScissorTestEnabled.GetHashCode());
    }
}