package org.tektutor;

public class Mobile {

	private ICamera camera;

	public Mobile( ICamera camera ) {
		this.camera = camera;
	}

	public boolean powerOn() {

		if ( camera.on() ) {
			System.out.println ("Mobile - powerOn positive code path ...");
			return true;
		}
		
		System.out.println ( "Mobile - powerOn negative code path...");
		return false;
	}

}
