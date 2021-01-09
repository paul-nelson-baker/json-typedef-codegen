package com.example;


import com.fasterxml.jackson.annotation.JsonInclude;

import com.fasterxml.jackson.annotation.JsonProperty;

import com.fasterxml.jackson.databind.annotation.JsonSerialize;

import java.util.Map;

/**
 * A Feature object represents a spatially bounded thing.  Every
 * Feature object is a GeoJSON object no matter where it occurs in a
 * GeoJSON text.
 * 
 * o  A Feature object has a "type" member with the value "Feature".
 * 
 * o  A Feature object has a member with the name "geometry".  The
 *     value of the geometry member SHALL be either a Geometry object
 *     as defined above or, in the case that the Feature is unlocated,
 *     a JSON null value.
 * 
 * o  A Feature object has a member with the name "properties".  The
 *     value of the properties member is an object (any JSON object or
 *     a JSON null value).
 */

@JsonSerialize

public class GeojsonObjectFeature extends GeojsonObject {

    
    @JsonProperty("geometry")
    private GeojsonObject geometry;

    
    @JsonProperty("properties")
    private Map<String, Object> properties;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    @JsonProperty("id")
    private Object id;


    public GeojsonObjectFeature() {
    }


    public GeojsonObject getGeometry() {
        return this.geometry;
    }

    public void setGeometry(GeojsonObject geometry) {
        this.geometry = geometry;
    }

    public Map<String, Object> getProperties() {
        return this.properties;
    }

    public void setProperties(Map<String, Object> properties) {
        this.properties = properties;
    }

    public Object getId() {
        return this.id;
    }

    public void setId(Object id) {
        this.id = id;
    }

}