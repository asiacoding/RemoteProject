package com.example.backendir;


import androidx.appcompat.app.AppCompatActivity;

import android.content.BroadcastReceiver;
import android.content.IntentFilter;
import android.os.Bundle;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {


   // int count = 0;
   // private TextView mBatteryLevelText;

    private BroadcastReceiver mReceiver;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.id.activity_main);


       // Button button = (Button) findViewById(R.id.button1);
     //   button.setOnClickListener(new View.OnClickListener() { @Override public void onClick(View v) {  }  });

        mReceiver = new PowerConnectionReceiver();
        PowerConnectionReceiver.mListener = () -> {
            TextView lbl = (TextView) findViewById(R.id.textView1);
           // count += 1;

            String Batterys = "\n Level : " + PowerConnectionReceiver.CurLevle +
                              "\n IsChnaged : " + PowerConnectionReceiver.Ischnaged +
                              "\n IsNotChnaged : " + PowerConnectionReceiver.IsNotChnaged +
                              "" ;

            lbl.setText(Batterys);
        };

    }



    @Override
    protected void onStart() {
        registerReceiver(mReceiver, new IntentFilter(Intent.ACTION_BATTERY_CHANGED));
        registerReceiver(mReceiver, new IntentFilter(Intent.ACTION_POWER_CONNECTED));
        registerReceiver(mReceiver, new IntentFilter(Intent.ACTION_POWER_DISCONNECTED));
        super.onStart();
    }

    @Override
    protected void onStop() {
      //  unregisterReceiver(mReceiver);
        super.onStop();
    }
}