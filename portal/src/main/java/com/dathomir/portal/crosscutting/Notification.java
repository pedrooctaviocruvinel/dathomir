package com.dathomir.portal.crosscutting;

import com.dathomir.portal.crosscutting.enums.ErrorCode;

import java.util.Collections;
import java.util.List;

public class Notification<T> {

    private final boolean success;
    private final int errorCode;
    private final List<String> errors;
    private final T data;

    public Notification(ErrorCode errorCode, List<String> errors, T data) {
        this.success = errorCode == ErrorCode.NO_ERROR;
        this.errorCode = errorCode.getValue();
        this.errors = errors;
        this.data = data;
    }

    public static <T> Notification<T> createSuccess(T data) {
        return new Notification<T>(ErrorCode.NO_ERROR, Collections.emptyList(), data);
    }

    public static <T> Notification<T> createError(ErrorCode errorCode) {
        return new Notification<T>(errorCode, Collections.emptyList(), null);
    }

    public static <T> Notification<T> createError(ErrorCode errorCode, List<String> errors) {
        return new Notification<T>(errorCode, errors, null);
    }

    public boolean getSuccess() {
        return success;
    }

    public int getErrorCode() {
        return errorCode;
    }

    public List<String> getErrors() {
        return errors;
    }

    public T getData() {
        return data;
    }

}
