# FiscalizationConnectorInterface

Facilitates integration of fiscalization between an accounting service and FDMS. This package is one-directional.

#

Map your accounting service models to the one provided by this service.

#

**v1.0.1**
Changed RegdResult.DeviceId type from string to ushort.
#
**v1.0.2**
Implemented fiscal day configuration request processing

**v2.0.0**
Added country to distinguish invoices based on the country.

###
**v2.1.0**
[Limited Socket Access]
*1.* Implemented sempaphore to limit socket access to one request at any given time.
*2.* Added a delay of 300ms as a temporary measure to resolve disposed connection isssue on multiple concurrent socket requests.

*NB:*
Implementation was in a bid to resolve disposed connection isssue on multiple concurrent socket requests. These changes are temporary while we work on implementing a SocketPool to requlate
the number of sockets that can be opened simultaneously.

###
**v2.1.1**
Updated dependencies

###
**v2.1.2**
[Socket Shutdown]
Replaced socket release with socket shutdown

###
**v2.1.3**
[Socket Close]
Implemented socket close in a finally block

###
**v2.1.4**
[Semaphore Implementation]
Implemented semaphore in Transactor to regulate number requests processed
