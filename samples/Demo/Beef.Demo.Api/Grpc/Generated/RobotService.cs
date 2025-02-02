/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using System;
using System.Net;
using System.Threading.Tasks;
using Beef;
using Beef.Grpc;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Beef.Demo.Common.Entities;
using Beef.Demo.Business;
using Beef.Demo.Common.Grpc;
using proto = Beef.Demo.Common.Grpc.Proto;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Api.Grpc
{
    /// <summary>
    /// Provides the <see cref="Robot"/> gRPC Server functionality.
    /// </summary>
    public partial class RobotService : proto.RobotGrpcService.RobotGrpcServiceBase
    {
        private readonly IRobotManager _manager;
        private readonly AutoMapper.IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotService"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IRobotManager"/>.</param>
        /// <param name="mapper">The <see cref="AutoMapper.IMapper"/>.</param>
        public RobotService(IRobotManager manager, AutoMapper.IMapper mapper)
            { _manager = Check.NotNull(manager, nameof(manager)); _mapper = Check.NotNull(mapper, nameof(mapper)); ServiceCtor(); }

        partial void ServiceCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the specified <see cref="Robot"/>.
        /// </summary>
        /// <param name="request">The <see cref="proto.RobotGetRequest"/>.</param>
        /// <param name="context">The <see cref="ServerCallContext"/>.</param>
        /// <returns>The <see cref="Robot"/>.</returns>
        public override Task<proto.Robot> Get(proto.RobotGetRequest request, ServerCallContext context)
        {
            return new GrpcService<proto.Robot>(context, async () =>
            {
                var __req = request ?? new proto.RobotGetRequest();
                var __result = await _manager.GetAsync(Transformers.GuidToStringConverter.ConvertToSrce(__req.Id));
                return _mapper.Map<Robot, proto.Robot>(__result!)!;
            }, operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound).ExecuteAsync();
        }

        /// <summary>
        /// Creates a new <see cref="Robot"/>.
        /// </summary>
        /// <param name="request">The <see cref="proto.RobotCreateRequest"/>.</param>
        /// <param name="context">The <see cref="ServerCallContext"/>.</param>
        /// <returns>The <see cref="Robot"/>.</returns>
        public override Task<proto.Robot> Create(proto.RobotCreateRequest request, ServerCallContext context)
        {
            return new GrpcService<proto.Robot>(context, async () =>
            {
                var __req = request ?? new proto.RobotCreateRequest();
                var __result = await _manager.CreateAsync(_mapper.Map<proto.Robot, Robot>(__req.Value)!);
                return _mapper.Map<Robot, proto.Robot>(__result!)!;
            }, operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null).ExecuteAsync();
        }

        /// <summary>
        /// Updates an existing <see cref="Robot"/>.
        /// </summary>
        /// <param name="request">The <see cref="proto.RobotUpdateRequest"/>.</param>
        /// <param name="context">The <see cref="ServerCallContext"/>.</param>
        /// <returns>The <see cref="Robot"/>.</returns>
        public override Task<proto.Robot> Update(proto.RobotUpdateRequest request, ServerCallContext context)
        {
            return new GrpcService<proto.Robot>(context, async () =>
            {
                var __req = request ?? new proto.RobotUpdateRequest();
                var __result = await _manager.UpdateAsync(_mapper.Map<proto.Robot, Robot>(__req.Value)!, Transformers.GuidToStringConverter.ConvertToSrce(__req.Id));
                return _mapper.Map<Robot, proto.Robot>(__result!)!;
            }, operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null).ExecuteAsync();
        }

        /// <summary>
        /// Deletes the specified <see cref="Robot"/>.
        /// </summary>
        /// <param name="request">The <see cref="proto.RobotDeleteRequest"/>.</param>
        /// <param name="context">The <see cref="ServerCallContext"/>.</param>
        /// <returns>The <see cref="Google.Protobuf.WellKnownTypes.Empty"/>.</returns>
        public override Task<Google.Protobuf.WellKnownTypes.Empty> Delete(proto.RobotDeleteRequest request, ServerCallContext context)
        {
            return new GrpcService<Google.Protobuf.WellKnownTypes.Empty>(context, async () =>
            {
                var __req = request ?? new proto.RobotDeleteRequest();
                await _manager.DeleteAsync(Transformers.GuidToStringConverter.ConvertToSrce(__req.Id));
                return new Google.Protobuf.WellKnownTypes.Empty();
            }, operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent).ExecuteAsync();
        }

        /// <summary>
        /// Gets the <see cref="RobotCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="request">The <see cref="proto.RobotGetByArgsRequest"/>.</param>
        /// <param name="context">The <see cref="ServerCallContext"/>.</param>
        /// <returns>The <see cref="RobotCollectionResult"/>.</returns>
        public override Task<proto.RobotCollectionResult> GetByArgs(proto.RobotGetByArgsRequest request, ServerCallContext context)
        {
            return new GrpcService<proto.RobotCollectionResult>(context, async () =>
            {
                var __req = request ?? new proto.RobotGetByArgsRequest();
                var __result = await _manager.GetByArgsAsync(_mapper.Map<proto.RobotArgs, RobotArgs>(__req.Args)!, __req.Paging == null ? new Entities.PagingArgs() : Transformers.PagingArgsToPagingArgsConverter.ConvertToSrce(__req.Paging));
                return _mapper.Map<RobotCollectionResult, proto.RobotCollectionResult>(__result!)!;
            }, operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent).ExecuteAsync();
        }
    }
}

#pragma warning restore
#nullable restore