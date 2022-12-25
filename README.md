## Theory

**Monolith applications** - just a fancy way of saying _all of the application features (фунции/возможности приложения) are bundled together as a single package_ (db/api/web/identity/reporting/outbound, etc.)

**Microservices applications** - takes the exact same ammount of features (db/api/web/identity/reporting/outbound, etc.) and splits each one out into its own mini application.


**Activities**:
- develop
- release/deploy (zero downtime)
- scale

Coordination VS integration patterns

Definition - compliance/checklist/protocol.

Two pizza team rule

**Kubernetes** - an orchestrator for cloud-native microservices applications (nodes/resources;desired state/actual state). OS of the Cloud.

Kubernetes abstracts (commoditizes) the underlying infrastructure the say way operating systems like Windows or Linux do (you don't have to care if your apps are running on Dell, Cisco, HPE, etc.). This is why it is called OS of the cloud (K8s runs on infrasturcture and applications run on K8s).

- deploy to any cloud (no vendor lock to some extent)
- switch to prem/other cloud where Kubernetes is supported


**Cloud-native**:
- Scale on demand
- Self-heal
- Zero-downtime updates
- Containerized

**Implementations/Distributives**

- EKS (Elastic Kubernetes Service)
- AKS (Azure Kubernetes Service)
- DOKS (Digital Ocean Kubernetes) https://docs.digitalocean.com/products/kubernetes/
- GKE (Google Kubernetes Engine)
- LKE (Linode Kubernetes Engine)

Cluster is a set of nodes (machines).
- master (control plane, no user apps). More than one for HA. 3-5. In different fault zones.
  - API server (direct ineraction via kubectl, API)
  - Scheduler (chooses wich nodes to run user application on)
  - Cloud Controller (integration with cloud services - storage/load-balancing)
  - Store etcd (where state is stored)
  
- worker (user apps)
  - kubelet (agent - communication with masters - receiving tasks/reporting on the status of the tasks)
  - Container runtime (starts/stops/manages containers)

## Configure kuberctl to talk to your cluster
- download kubeconfig
- integrate with existing <username>\.kube\config
- create a standalone config (will be picked up by Lens for instance)

## Resources

https://learn.microsoft.com/en-us/training/modules/dotnet-deploy-microservices-kubernetes/

## Tools

- https://k8slens.dev/
- https://github.com/ahmetb/kubectx


## Troubleshooting

```console
kubectl run one-off --rm --restart=Never -it --image=praqma/network-multitool -- sh -l
lens> Pod Shell
```

## Workflows

**docker image** and **docker container** are two main actors

```console
docker build -t arturkarbone/letskube:v1 .
docker image build -t arturkarbone/letskube:v1 .
docker image list
docker run -p 8080:80 arturkarbone/letskube #play with console logs
docker container run -p 8080:80 arturkarbone/letskube #play with console logs
docker push arturkarbone/letskube:v1 #check container registry
docker image push arturkarbone/letskube:v1 #check container registry
docker tag pizzabackend arturkarbone/pizzabackend #build without image registry and tag later
```

http://localhost:8001/api/v1/namespaces/default/services/letskube-service/proxy/

```console
kubectl get nodes
export pod=letskube-deployment-677b479cb4-rmb45
kubectl get pod $pod -o yaml (check config)
kubectl describe pod $pod
kubectl exec $pod -it sh
kubectl get events
kubectl get event --field-selector involvedObject.name=$pod
kubectl proxy
kubectl port-forward svc/kubeview1 8080:80 namespace kubeview
```
