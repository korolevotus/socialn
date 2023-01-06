# OTUS Highload архитектор. Домашнее задание. Простейшая социальная сеть
Чтобы запустить проект, используйте docker

```
docker build -f "OTUSHigloadTestProject/Dockerfile" -t korolevdimage .
```

далее

```
docker run -it \
    -e "ASPNETCORE_ENVIRONMENT=Development" \
    -e "ASPNETCORE_URLS=http://+:80"\
    --name OTUSHighload.korolevd\
    -p 44390:80 korolevdimage\
```
