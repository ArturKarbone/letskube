"# letskube" 

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
