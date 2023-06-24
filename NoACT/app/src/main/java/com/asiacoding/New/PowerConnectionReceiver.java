package com.example.backendir;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;

public class PowerConnectionReceiver extends BroadcastReceiver {

    public interface OnCustomEventListener {
        void onEvent();
    }

   public static OnCustomEventListener mListener;

    public void setCustomEventListener(OnCustomEventListener eventListener) {
        mListener = eventListener;
    }



    private final static String BATTERY_LEVEL = "level";

    public static String CurLevle = "";
    public static boolean Ischnaged = false;
    public static boolean IsNotChnaged = true;

    @Override
    public void onReceive(Context context, Intent intent) {



        if (intent.getAction() == Intent.ACTION_POWER_CONNECTED || intent.getAction() == Intent.ACTION_POWER_DISCONNECTED) {
            PowerConnectionReceiver.Ischnaged = (intent.getAction() == Intent.ACTION_POWER_CONNECTED);
            PowerConnectionReceiver.IsNotChnaged = (intent.getAction() == Intent.ACTION_POWER_DISCONNECTED);
        }
        else
        {
            int level = intent.getIntExtra(BATTERY_LEVEL, 0);
            PowerConnectionReceiver.CurLevle = context.getString(R.string.battery_level) + " " + level;
        }


        mListener.onEvent();
    }



}