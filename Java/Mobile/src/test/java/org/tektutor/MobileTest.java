package org.tektutor;

import org.junit.Test;
import static org.junit.Assert.*;
import static org.mockito.Mockito.*;

public class MobileTest {

	@Test
	public void testPowerOn() {

		//Mocking
		ICamera mockedCamera = mock (ICamera.class);

		//Stubbing - hard coding the response of on method
		when(mockedCamera.on()).thenReturn(true);	

		Mobile mobile = new Mobile( mockedCamera );

		boolean actualResponse = mobile.powerOn();
		boolean expectedResponse = true;

		assertEquals ( expectedResponse, actualResponse );

		verify ( mockedCamera, times(1) ).on();
	}

}
