"# letskube" 


kubectl proxy
http://localhost:8001/api/v1/namespaces/default/services/letskube-service/proxy/


> kubectl get pod letskube-deployment-64d58c4966-4gwfs -o yaml (check config)
> kubectl exec letskube-deployment-5c9f95c675-5r7sd -it sh