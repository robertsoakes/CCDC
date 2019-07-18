# FROM alpine:latest
# RUN apk update && apk add --update alpine-sdk
# RUN mkdir /source
# COPY hello.c /source/hello.c
# RUN gcc -o hello /source/hello.c
# CMD ./hello

FROM alpine:latest AS BUILD
RUN apk update && apk add --update alpine-sdk
RUN mkdir /source
COPY hello.c /source/hello.c
RUN gcc -o hello /source/hello.c

FROM alpine:latest
COPY --from=build /hello /hello
CMD ./hello