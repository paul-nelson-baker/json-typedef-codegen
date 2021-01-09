package com.example;


import com.fasterxml.jackson.annotation.JsonCreator;

import com.fasterxml.jackson.annotation.JsonValue;

/**

 */

public class Bar {
    @JsonValue
    private Bar0 value;

    public Bar() {
    }

    @JsonCreator
    public Bar(Bar0 value) {
        this.value = value;
    }

    public Bar0 getValue() {
        return value;
    }

    public void setValue(Bar0 value) {
        this.value = value;
    }
}