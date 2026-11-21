package com.dathomir.portal.crosscutting.enums;

public enum ErrorCode {
    NO_ERROR(0);

    private final int value;

    ErrorCode(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

}
