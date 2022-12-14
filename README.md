"# letskube" 

**Monolith applications** - just a fancy way of saying _all of the application features are bundled together as a single package_ (db/api/web/identity/reporting/outbound, etc.)

**Microservices applications** - takes the exact same ammount of features (db/api/web/identity/reporting/outbound, etc.) and splits each one out into its own mini application.

**Activities**:
- develop
- deploy (zero downtime)
- scale

Coordination VS integration patterns

Definition - compliance/checklist/protocol.

Two pizza team rule

```console
docker build -t arturkarbone/letskube:v1 .
docker images
docker run -p 8080:80 arturkarbone/letskube #play with console logs
docker push arturkarbone/letskube:v1 #check container registry
```

http://localhost:8001/api/v1/namespaces/default/services/letskube-service/proxy/

```console
export pod=letskube-deployment-677b479cb4-rmb45
kubectl get pod $pod -o yaml (check config)
kubectl describe pod $pod
kubectl exec $pod -it sh
kubectl get events
kubectl get event --field-selector involvedObject.name=$pod
kubectl proxy
kubectl port-forward svc/kubeview1 8080:80 namespace kubeview
```
