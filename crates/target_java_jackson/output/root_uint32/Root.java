package com.example;


import com.fasterxml.jackson.annotation.JsonCreator;

import com.fasterxml.jackson.annotation.JsonValue;

/**

 */

public class Root {
    @JsonValue
    private UnsignedInteger value;

    public Root() {
    }

    @JsonCreator
    public Root(UnsignedInteger value) {
        this.value = value;
    }

    public UnsignedInteger getValue() {
        return value;
    }

    public void setValue(UnsignedInteger value) {
        this.value = value;
    }
}