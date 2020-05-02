#version 410

uniform sampler2D tex;

in vec4 v_color;
in vec2 v_uv;
in vec3 v_viewpos;

out vec4 frag_color;

uniform vec4 fog_color;
uniform float fog_near;
uniform float fog_far;

void main() {
    frag_color = texture(tex, v_uv) * v_color;

    // disance fog
    float fog = smoothstep(fog_near, fog_far, length(v_viewpos));
    frag_color = mix(frag_color, fog_color, fog);

    // gamma correction
    frag_color = vec4(pow(frag_color.rgb, vec3(1.0 / 2.2)), frag_color.a);
}