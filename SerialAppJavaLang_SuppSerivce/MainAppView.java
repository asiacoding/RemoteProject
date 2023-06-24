package com.hoho.android.usbserial.examples;

import android.hardware.usb.UsbDevice;
import android.os.Bundle;

import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;

import android.util.Log;
import android.view.View;

import androidx.core.view.WindowCompat;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import com.hoho.android.usbserial.MainWorkCom;
import com.hoho.android.usbserial.driver.UsbSerialDriver;
import com.hoho.android.usbserial.examples.databinding.ActivityMainAppViewBinding;

public class MainAppView extends AppCompatActivity {

    private AppBarConfiguration appBarConfiguration;
    private ActivityMainAppViewBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMainAppViewBinding.inflate(getLayoutInflater());
        setContentView(R.layout.main_appview);

        setSupportActionBar(binding.toolbar);

        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main_app_view);
        appBarConfiguration = new AppBarConfiguration.Builder(navController.getGraph()).build();
        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);

        binding.fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAnchorView(R.id.fab)
                        .setAction("Action", null).show();
            }
        });
    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main_app_view);
        return NavigationUI.navigateUp(navController, appBarConfiguration)
                || super.onSupportNavigateUp();

    }

    public void clickstart(View view) {
        MainWorkCom objCom = new MainWorkCom();
        objCom.thisContext = this;
        UsbSerialDriver CurCom = objCom.getConnectUSBSerial();

        if (CurCom != null){
            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.LOLLIPOP)
            {
                UsbDevice usb =CurCom.getDevice();

                //String MainValues = "";

              //  MainValues+=usb.getProductName() + "\n";
            //    MainValues+=usb.getProductId() + "\n";



          //      Log.d("Get1", MainValues);
            }else{
        //        Log.d("Get1", "Strart CLick" );
            }
        }


        //textView1
      //  Log.d("Get1", "Strart CLick" );

    }
}